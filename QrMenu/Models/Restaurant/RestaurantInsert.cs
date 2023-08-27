﻿using System.ComponentModel.DataAnnotations;

namespace QrMenu.Models.Restaurant
{
    public class RestaurantInsert
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string MenuLink { get; set; }
	}
}

