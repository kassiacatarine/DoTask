using System;
using System.Collections.Generic;
using System.Text;

namespace DoTask.Domain.SeedWork
{
    public abstract class Entity
    {
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
        public bool Removed { get; set; }

        public virtual void Remove()
        {
            Removed = true;
        }
    }
}
