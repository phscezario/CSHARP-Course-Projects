using System;

namespace Basic.CRUD
{
    public class Item : BaseEntity
    {
        // Attribute

        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Item(int Id, Genre genre, string title, string description, int year)
        {
            this.Id = Id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        // Overwrite ToString()
        public override string ToString()
        {
            // Envonment.NewLine add line-break on any operation system
            string result = "";
            result += "Genre: = " + this.Genre + Environment.NewLine; 
            result += "Title: = " + this.Title + Environment.NewLine; 
            result += "Description: = " + this.Description + Environment.NewLine; 
            result += "Year: = " + this.Year + Environment.NewLine;
            result += "Delected: = " + this.Deleted;

            return result;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnDeleted()
        {
            return this.Deleted;
        }

        public void Exclude()
        {
            this.Deleted = true;
        }
    }
}