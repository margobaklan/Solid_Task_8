using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Цей клас порушує принцип єдиного обов’язку, так як розв’язує одразу три задачі

namespace Solid1
{
    //Який принцип S.O.L.I.D. порушено? Виправте!
    class Item
    {

    }
    class Order
    {
        private List<Item> itemList;

        internal List<Item> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }
        //керує елементами замовлення
        public void CalculateTotalSum() {/*...*/}
        public void GetItems() {/*...*/}
        public void GetItemCount() {/*...*/}
        public void AddItem(Item item) {/*...*/}
        public void DeleteItem(Item item) {/*...*/}
              
    }
    //керує інформацією замовлення
    class OrderRepository
    {
        public void Load(Order order) {/*...*/}
        public void Save(Order order) {/*...*/}
        public void Update(Order order) {/*...*/}
        public void Delete(Order order) {/*...*/}
    }
    //друкує чи демонструє інформацію замовлення
    class PrintManager
    {
        public void PrintOrder(Order order) {/*...*/}
        public void ShowOrder(Order order) {/*...*/}
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
