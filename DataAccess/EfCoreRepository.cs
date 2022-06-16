using System.Linq.Expressions;
using System.Reflection;
using DataAccess.Extensions;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess;

public class EfCoreRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _elements;

    public EfCoreRepository(DbContext context)
    {
        _context = context;
        _elements = context.Set<T>();
    }

    public void Attach(T entity)
    {
        _context.Attach(entity);
    }

    public bool Exist(Expression<Func<T, bool>> condition)
    {
        return _elements.AsNoTracking().Any(condition);
    }

    public T Get(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, T>> selector = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool track = false)
    {
        return _elements.TrackElements(track).Where(condition).NullableInclude(include).NullableSelect(selector)
            .First();
    }

    public void InsertAndSave(T entity)
    {
        _elements.Add(entity);
        SaveChanges();
    }

    public void Insert(T entity)
    {
        _elements.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void UpdateAndSave(T entity)
    {
        _context.Entry<T>(entity).State = EntityState.Modified;

        SaveChanges();
    }

    public void Load<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression) where TProperty : class
    {
        _context.Entry(entity).Reference(propertyExpression).Load();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IEnumerable<T> GetCollection(
        Expression<Func<T, bool>>? condition = null,
        Expression<Func<T, T>>? selector = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        var elements = _elements.AsNoTracking().NullableWhere(condition).NullableInclude(include)
            .NullableOrderBy(orderBy).NullableSelect(selector).ToList();

        return elements;
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public void DeleteByIdAndSave(object id)
    {
        DeleteByIdsAndSave(new List<object> { id });
    }

    public void DeleteByIdsAndSave(IEnumerable<object> ids)
    {
        var entities = new List<T>();

        var typeInfo = typeof(T).GetTypeInfo();
        var key = _context.Model.FindEntityType(typeInfo)?.FindPrimaryKey()?.Properties.FirstOrDefault();
        var property = typeInfo.GetProperty(key?.Name);

        foreach (var id in ids)
        {
            T entity;
            if (property != null)
            {
                entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
            }
            else
            {
                entity = _elements.Find(id);
            }

            entities.Add(entity);
        }

        _context.RemoveRange(entities);
        _context.SaveChanges();
    }
}