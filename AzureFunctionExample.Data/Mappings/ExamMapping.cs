using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionExample.Data.MongoDB.Mappings
{
    public class ExamMapping : IMapping
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Exam>(map =>
            {
                map.AutoMap();
            });
        }
    }
}
