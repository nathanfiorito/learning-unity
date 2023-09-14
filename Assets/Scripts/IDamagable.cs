﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IDamagable
    {
        public float Health { get; set; }

        public void OnHit(float damage);
    }
}
