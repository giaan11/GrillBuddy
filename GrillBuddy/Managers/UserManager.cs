
using GrillBuddy.DAL.Data;
using GrillBuddy.DAL.Entities;
using GrillBuddy.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillBuddy.Managers
{
    public class UserManager 
    {

        public static UtenteDTO GetSingle(string id)
        {
            var found = GetAll().SingleOrDefault(x => x.UtenteId == id);
            if (found != null)
            {
                return found;
            }
            throw new Exception("Not Found");
        }

        public static List<UtenteDTO> GetAll()
        {
            return new List<UtenteDTO>();
        }

    }
}
