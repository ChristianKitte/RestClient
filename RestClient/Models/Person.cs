﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestClient.Models
{
    public class Person
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Person()
        {
            Vorname = string.Empty;
            Nachname = string.Empty;
        }
        
        /// <summary>
        /// Die ID der Person 
        /// </summary>
        [Key]
        public int PersonID { get; set; }

        /// <summary>
        /// Der Vorname der Person                  
        /// </summary>
        [Required]
        public string Vorname { get; set; }

        /// <summary>
        /// Der Nachname der Person 
        /// </summary>
        [Required]
        public string Nachname { get; set; }

        /// <summary>
        /// Überschreibt die ToString() Methode
        /// </summary>
        /// <returns>Einen String, der die Entität beschreibt</returns>
        public override string ToString()
        {
            return String.Format("Person mit der ID {0} und dem Namen {1} {2} wurde geholt",
                new String[] {this.PersonID.ToString(), this.Vorname, this.Nachname});
        }
    }
}