using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fruits 
{
    public  class ManagerFruits :Validate
      
    {
        
        int  NumberOFOrder = 1; 
        public List<Fruits> listFruits = new List<Fruits>();
        StringBuilder order  = new StringBuilder();
        public List<Fruits> giohang = new List<Fruits>();
        Dictionary<int, String> HistoryOrder = new Dictionary<int, string>();
        DateTime date = DateTime.Now;
        public void addFruits ()
        {

            // trong C# sử dung từ khóa base để gọi các phương thức từ  lớp cha( tương tự như trong java thì dùng super)
            int id = listFruits[listFruits.Count - 1].ID+1;
            Console.Write("Nhập Tên Fuirt:");
            String name = base.inputName();
            foreach(Fruits s in listFruits)
            {
                if(s.Name.Equals(name))
                {
                    int oldQuanlity = s.Quanlity;
                    Console.Write("Bạn có muốn tiếp tục thêm {0} (Y/N):",s.Name);
                    String choieADD = Console.ReadLine().ToUpper();
                    if( choieADD.Equals("Y") ) {
                        Console.Write("Nhập Số Lượng :");
                        s.Quanlity = s.Quanlity+ base.inputNumer();
                        Console.WriteLine("                          THÔNG BÁO    ");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("|       Product :{0} | Số lượng cũ :{1} | Số lượng mới :{2}          ", s.Name,oldQuanlity,s.Quanlity);
                        Console.WriteLine("----------------------------------------------------------------------");
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Console.Write("Nhập Giá bán :");
            double price = base.inputDouble();
            Console.Write("Nhập Số Lượng :");
            int quanlity = base.inputNumer();
            Console.WriteLine("Nhập quốc gia xuất xử :");
            String orgin = base.inputOrgin();         
            listFruits.Add(new Fruits(id, name, price, quanlity, orgin));   
            Console.WriteLine("Thêm thành công !");
        }

        public void danhsach()
        {
            listFruits.Add(new Fruits(1, "Táo", 4000, 1000, "Việt Nam"));
            listFruits.Add(new Fruits(2, "Cam", 5000, 1200, "Việt Nam"));
            listFruits.Add(new Fruits(3, "Chuối", 3000, 1500, "Thái Lan"));
            listFruits.Add(new Fruits(4, "Nho", 7000, 800, "Mỹ"));
            listFruits.Add(new Fruits(5, "Dưa hấu", 6000, 1300, "Việt Nam"));
            listFruits.Add(new Fruits(6, "Măng cụt", 12000, 600, "Thái Lan"));
            listFruits.Add(new Fruits(7, "Lê", 8000, 900, "Châu Âu"));
            listFruits.Add(new Fruits(8, "Xoài", 10000, 1100, "Ấn Độ"));
            listFruits.Add(new Fruits(9, "Dứa", 4000, 1400, "Việt Nam"));
            listFruits.Add(new Fruits(10, "Lựu", 9000, 700, "Iran"));

        }


        public void DisplayMenu()
        {
            if (listFruits.Count == 0)
            {
                Console.WriteLine("Danh Sách Rỗng");
                return;
            }

            StringBuilder menu = new StringBuilder();
            menu.AppendLine("---------------------------------------------------------------------------------------------");
            menu.AppendLine(String.Format("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|", "ID", "Product", "Price", "Quantity", "Origin"));
            menu.AppendLine("---------------------------------------------------------------------------------------------");

            foreach (Fruits s in listFruits)
            {    // {0,-10}  => hiểu là chứa value của biến có index 0 và cách trái 10 ký tự 
                menu.AppendLine(String.Format("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|", s.ID, s.Name, s.Price, s.Quanlity, s.Orgin));
            }
            // sửa xong

            Console.WriteLine(menu.ToString());         
        }


      
            int Code = 1;
        public void shopping()
        {
            Console.WriteLine("Xin Kính Chào Qúy Khách");
            DisplayMenu();

            Console.Write("Nhập Tên Khách Hàng :");
            
            String nameCustomer = base.inputName();
            int soluong;
           
            while (true)
            {
                Console.Write("Nhập ID Product để thêm vào giỏ hàng :");
                int id = base.checkID(listFruits);

                foreach(Fruits s  in listFruits)
                {
                    if(s.ID== id)
                    {

                        while(true)
                        {
                          soluong = base.purchasequantity();
                            if(soluong>s.Quanlity)
                            {
                                Console.WriteLine("Sản phẩm "+s.Name + " chỉ còn số lượng là :" + s.Quanlity);
                                Console.Write("Bạn có muốn tiếp tục mua {0} ? (Y/N)",s.Name);
                                char choices = Char.ToUpper(Console.ReadLine()[0]);
                                if(choices =='Y')
                                {
                                    continue;
                                }
                               
                            }
                            break;
                        }
                        s.Quanlity = s.Quanlity-soluong;

                        bool check = false;
                        foreach (Fruits t  in giohang)
                        {
                            if(t.ID==id)
                            {
                                t.Quanlity=t.Quanlity+soluong;
                                check = true;
                                break;
                            }
                        }

                        if(!check)
                        {
                        giohang.Add(new Fruits(s.ID, s.Name, s.Price, soluong, s.Orgin));
                        Console.WriteLine("(System) đã thêm vào rỏ hàng ");                     
                        }
                           break;                      
                    }
                }

                DisplayMenu();

                Console.Write("Bạn muốn tiếp tục mua sắm chứ ? (Y/N)");
                
                char choice = char.ToUpper(Console.ReadLine()[0]);
                // Console.ReadLine()[0] ; lấy ký tự đàu tiên viết hoa
                if (choice!='Y')
                {

                    order.AppendLine("   \n      ");
                    order.AppendLine("                                               HÓA ĐƠN BÁN HÀNG      ");
                    order.AppendLine("FRUIT VTP");
                    order.AppendLine("Số hóa đơn :"+(NumberOFOrder++));
                    order.AppendLine("Tên khách hàng :" + nameCustomer);
                    order.AppendLine("Thời gian mua hàng :" +date);
                    order.AppendLine("-----------------------------------------------------------------------------------------------------------------------");
                    order.AppendLine(String.Format("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-20}|", "STT", "Product", "Price", "Quantity", "Origin","Amount"));
                 
                    double TotalAmount = 0;
                    int NUmberOFProduct = 1;
                    foreach (Fruits k in giohang)
                    {
                        order.AppendLine(String.Format("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}| {5,-20}",NUmberOFProduct++, k.Name,k.Price,k.Quanlity,k.Orgin,(k.Quanlity*k.Price)+" VND"));
                        TotalAmount = TotalAmount + (k.Quanlity * k.Price);
                    }
                    TotalAmount = TotalAmount + (TotalAmount*0.03);
                    order.AppendLine("Thành Tiền Sau VAT :" +TotalAmount+" VND" );
                    order.AppendLine("XIN CẢM ƠN QUÝ KHÁCH ĐÃ TIN TƯỞNG SỬ DỤNG DỊCH VỤ");
                    String myorder = order.ToString();
                    HistoryOrder.Add(Code, myorder);
                    ++Code;
                    order.Clear();
                    return;
                }
                else
                {
                    continue;
                }

            }

        }




        public void ManagerOrder()
        {
            while(true)
            {
               
                Console.Write("Nhập Code Hóa Đơn:");            
                int Code = int.Parse(Console.ReadLine());          
                if(! HistoryOrder.ContainsKey(Code))                        
                {
              
                    Console.WriteLine("Không tồn tại Code "+Code);
                    Console.Write("Bạn có  muốn tiếp tục (Y/N):");
                    char choice = char.ToUpper(Console.ReadLine()[0]);
                    if(choice=='Y')
                    {
                        continue;
                    }
                    else
                    {
                        return;               
                    }
                }
                Console.WriteLine(HistoryOrder[Code]);
                return;
            }

        }

    }
}

