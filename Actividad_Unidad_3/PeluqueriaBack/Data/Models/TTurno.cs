﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeluqueriaBack.Data.Models;

public partial class TTurno
{
    public int Id { get; set; }

    [StringLength(10)]
    public string Fecha { get; set; }
    [StringLength(5)]
    public string Hora { get; set; }

    public string Cliente { get; set; }

    public DateOnly? FechaCanc { get; set; }

    public string MotivoCanc { get; set; }


}