using ListaProzivoda.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace ListaProzivoda.Repositories.JSON
{
    public class JsonFileRepository : IRepository<Proizvod>
    {
        string _filePath;
        List<Proizvod> proizvods;
        public JsonFileRepository(string filePath)
        {
            _filePath = filePath;
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            if (!File.Exists(filePath))
            {
                
                File.Create(filePath).Close(); 
            }

            var json = File.ReadAllText(filePath);
            proizvods = JsonConvert.DeserializeObject<List<Proizvod>>(json) ?? new List<Proizvod>();
            
        }
        public void Create(Proizvod p)
        {
            p.Id = (proizvods.LastOrDefault()?.Id ?? 0) + 1;
            proizvods.Add(p); 
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            proizvods.Remove(p);
        }

        public void Edit(Proizvod p)
        {
            int pi = proizvods.FindIndex(a => a.Id == p.Id);
            proizvods[pi] = p;
        }

        public List<Proizvod> GetAll()
        {
            return proizvods;
        }

        public Proizvod GetById(int id)
        {
            return proizvods.SingleOrDefault(a => a.Id == id);
        }

        public void SaveChanges()
        {
            string json = JsonConvert.SerializeObject(proizvods);
            File.WriteAllText(_filePath, json);
        }
    }
}