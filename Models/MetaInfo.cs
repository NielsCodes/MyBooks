using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InleverOpdracht1.Models
{
    public class MetaInfo
    {
        private int _id;
        private string _name;

        public MetaInfo(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get => _id; }
        public string Name { get => _name; set => _name = value; }
    }
}