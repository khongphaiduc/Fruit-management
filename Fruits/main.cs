using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fruits
{
    public  class main
    {

        public static void Main(string[] args)
        {
            Validate  s1 = new Validate();
            ManagerFruits obj = new ManagerFruits();
            obj.danhsach();
            while (true)
            {
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("MUA SẮM TẸT GA KHÔNG LO VỀ GIÁ");
            

                Console.WriteLine("1.Thêm new Product ");
                Console.WriteLine("2.Mua Sắm");
                Console.WriteLine("3.Hóa Đơn");
                Console.WriteLine("4.EXits");
                Console.Write("Xin mời nhập lựa chọn của bạn :");
                int choice = s1.inputOPTION();

                switch (choice)
                {
                    case 1:
                    {
                            obj.addFruits();
                            break;
                    }
                    case 2:
                    {
                            obj.shopping();
                            break;
                    }
                   case 3:
                   {
                            obj.ManagerOrder();
                            break;
                   }
                   case 4:
                   {
                            Console.WriteLine("Thoát !");
                            return;
                   }
                }

            }

        }
    }
}
