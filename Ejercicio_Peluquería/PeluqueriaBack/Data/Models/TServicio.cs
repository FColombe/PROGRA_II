﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PeluqueriaBack.Data.Models;

public partial class TServicio
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int Costo { get; set; }

    public string EnPromocion { get; set; }

    [JsonIgnore]
    public virtual ICollection<TDetallesTurno> TDetallesTurnos { get; set; } = new List<TDetallesTurno>();
}