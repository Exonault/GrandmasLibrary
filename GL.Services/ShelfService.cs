﻿using System;
using System.Linq;
using GL.Model.Context;
using GL.Model.Model;

namespace GL.Services
{
    public class ShelfService
    {
        private readonly LibraryContext _context;

        public ShelfService(LibraryContext context  )
        {
            _context = context;
        }

        public void AddShelf(string shelfName)
        {
            Shelf shelf=new Shelf();
            shelf.ShelfName = shelfName;
            _context.Shelves.Add(shelf);
            _context.SaveChanges();
        }
        
        public void DeleteShelf( string shelfName)
        {
            Shelf shelf = _context.Shelves.Find(shelfName);
            _context.Shelves.Remove(shelf);
            _context.SaveChanges();
        }
       
        public string ViewShelves()
        {
            var shelves = _context.Shelves.Select(c => c.ShelfName).ToList();
            string allShelves = "Library have the following shelfs: \n";
            foreach (var shelf in shelves)
            {
                allShelves += shelf + "\n";
            }

            return allShelves;
        }
       
        public void ChangeName(string currentName, string newName)
        {
            Shelf shelf = _context.Shelves.Find(currentName);
            shelf.ShelfName = newName;
            _context.SaveChanges();
        }
        
    }
}