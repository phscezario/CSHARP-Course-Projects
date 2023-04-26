using System;
using System.Collections.Generic;
using Basic.CRUD.Interfaces;

namespace Basic.CRUD
{
    public class ItemRepository : IRepository<Item>
    {
        private List<Item> itemList = new List<Item>();

        public void Delete(int id)
        {
            itemList[id].Exclude();
        }

        public void Insert(Item element)
        {
            itemList.Add(element);
        }

        public List<Item> List()
        {
            return itemList;
        }

        public int NextId()
        {
            return itemList.Count;
        }

        public Item ReturnToId(int id)
        {
            return itemList[id];
        }

        public void Update(int id, Item element)
        {
            itemList[id] = element;
        }
    }
}