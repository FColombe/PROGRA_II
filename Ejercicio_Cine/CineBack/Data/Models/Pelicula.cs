﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CineBack.Data.Models;

public partial class Pelicula
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Director { get; set; }

    public int Anio { get; set; }

    public bool Estreno { get; set; }

    public int IdGenero { get; set; }

    [JsonIgnore]
    public virtual Genero IdGeneroNavigation { get; set; }
}