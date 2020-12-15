﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Data
{
    public class SeedData
    {
        private readonly DataContext _context;
        public SeedData(DataContext context)
        {
            _context = context;
        }
        public void EnsurePopulated()
        {
            if (!_context.Products.Any())
            {
                _context.Products.AddRange(
                   new Product
                   {
                       Name = "Kajak",
                       Description = "Łódka przeznaczona dla jednej osoby",
                       Category = "Sporty wodne",
                       Price = 275
                   }, new Product
                   {
                       Name = "Kamizelka ratunkowa",
                       Description = "Chroni i dodaje uroku",
                       Category = "Sporty wodne",
                       Price = 48.95m
                   }, new Product
                   {
                       Name = "Piłka",
                       Description = "Zatwierdzone przez FIFA rozmiar i waga",
                       Category = "Piłka nożna",
                       Price = 19.50m
                   }, new Product
                   {
                       Name = "Flagi narożne",
                       Description = "Nadadzą twojemu boisku profesjonalny wygląd",
                       Category = "Piłka nożna",
                       Price = 34.95m
                   }, new Product
                   {
                       Name = "Stadion",
                       Description = "Składany stadion na 35 000 osób",
                       Category = "Piłka nożna",
                       Price = 79500
                   }, new Product
                   {
                       Name = "Czapka",
                       Description = "Ciepło w głowę to więcej skupienia",
                       Category = "Szachy",
                       Price = 16
                   },
                   new Product
                   {
                       Name = "Niestabilne krzesło",
                       Description = "Zmniejsza szanse przeciwnika",
                       Category = "Szachy",
                       Price = 29.95m
                   },
                   new Product
                   {
                       Name = "Ludzka szachownica",
                       Description = "Przyjemna gra dla całej rodziny",
                       Category = "Szachy",
                       Price = 75
                   },
                   new Product
                   {
                       Name = "Błyszczący król",
                       Description = "Figura pokryta złotem i wysadzana diamentami",
                       Category = "Szachy",
                       Price = 1200
                   }
            );
                _context.SaveChanges();
            }
        }
    }
}
