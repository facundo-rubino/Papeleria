﻿using System;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }

        public TipoMovimiento()
        {
        }
    }
}
