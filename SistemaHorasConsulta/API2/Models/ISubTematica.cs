﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace API.Models
{
    public class ISubTematica:SubTematica
    {
        public ISubTematica getSubTematica(int id)
        {
            return new ISubTematica();
        }

    }
}