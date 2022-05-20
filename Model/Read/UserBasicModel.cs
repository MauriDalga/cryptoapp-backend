using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Model.Read;
public class UserBasicModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    public UserBasicModel(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Lastname = user.Lastname;
    }

    public override bool Equals(object obj)
    {
        var result = false;

        if (obj is UserBasicModel user)
        {
            result = Id == user.Id &&
                Name.Equals(user.Name) &&
                Lastname.Equals(user.Lastname);
        }

        return result;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}