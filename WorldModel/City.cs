using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorldModel;

[Table("City")]
public partial class City
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("COUNTRY_ID")]
    public int CountryId { get; set; }

    [Column("CITY_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string CityName { get; set; } = null!;

    [Column("LATITUDE")]
    public double Latitude { get; set; }

    [Column("LONGITUDE")]
    public double Longitude { get; set; }

    [Column("POPULATION")]
    public int Population { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
