using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_014
{
	class Node
	{
		//Deklarasi Variabel
		public int noBuku;
		public string judulBuku;
		public string namaPengarang;
		public int tahunTerbit;
		public Node next;
		public Node prev;
	}
	class List //membuat class list
	{
		Node START; //deklarasi node start
		public List() 
		{
			START = null;
		}
		public void tambah() //tambah node ke dalam list
		{
			int no, tahun;
			string nama, judul;
			Console.Write("\nMasukkan Nomor Buku: ");//input variabel
			no = Convert.ToInt32(Console.ReadLine());
			Console.Write("\nMasukkan Judul Buku: ");
			judul = Console.ReadLine();
			Console.Write("\nMasukkan Tahun Terbit nya Buku:  ");
			tahun = Convert.ToInt32(Console.ReadLine());
			Console.Write("\nMasukkan Nama Pengarang: ");
			nama = Console.ReadLine();

			Node newnode = new Node();

			newnode.noBuku = no; //deklarasi noBuku = no 
			newnode.judulBuku = judul;
			newnode.tahunTerbit = tahun;
			newnode.namaPengarang = nama;

			if (START == null || no <= START.noBuku)// jika terdapat duplicate nomor
            {
                if ((START != null) && (no == START.noBuku))
                {
                    Console.WriteLine("Duplikat nomor buku tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
			Node previous, current;
			previous = START;
			current = START;

			while ((current != null) && (no >= current.noBuku))
			{
				if (no == current.noBuku)
				{
					Console.WriteLine("\nNomor Buku Sama Tidak di Izinkan\n");
					return;
				}
				previous = current;
				current = current.next;
			}
			newnode.next = current;
			previous.next = newnode;
		}
		//Method untuk menge-Check apakah Node yang dimaksud ada di dalam list
        public bool search(int th, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (th != current.tahunTerbit))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }
		//Method untuk traverse/mengunjungi dan membaca isi list
		public void traverse()
		{
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList Data Mahasiswa : ");
                Console.Write("Nomor Buku" + "   " + "Nama Pengarang" + "    " + "Tahun terbit" + "   " + "Judul Buku" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.noBuku + "    " + 
						currentNode.judulBuku + "    " + 
						currentNode.tahunTerbit + "         " + 
						currentNode.namaPengarang + "\n");
                }
                Console.WriteLine();
            }
        }
		public bool listEmpty()
		{
			if (START == null)
				return true;
			else
				return false;
		}
		class Program
		{
			static void Main(string[] args)
			{
				List obj = new List(); //membuat list baru
				while (true)
				{
					try
					{
						//membuat tampilan menu
						Console.WriteLine("\nMenu ");
						Console.WriteLine("1. Menambah Data ke Dalam List ");
						Console.WriteLine("2. Menampilkan Semua Data di Dalam List ");
						Console.WriteLine("3. Mencari Sebuah Data di Dalam List ");
						Console.WriteLine("4. Exit ");
						Console.Write("\nMasukkan Pilihan Anda (1-4): ");
						char ch = Convert.ToChar(Console.ReadLine());
						switch (ch)
						{
							case '1'://jika milih 1 maka akan menjalankan program tambah data
								{
									obj.tambah();
								}
								break;
							case '2': //pengurutan data dengan quick sort
								{
									obj.traverse();
								}
								break;
							case '3':
								{
									if (obj.listEmpty() == true)
									{
										Console.WriteLine("\nList Kosong !");
										break;
									}
									Node previous, current;
									previous = current = null;
									Console.Write("\nMasukkan Tahun Terbit Buku Yang Ingin Ditemukkan: ");
									int num = Convert.ToInt32(Console.ReadLine());
									if (obj.search(num, ref previous, ref current) == false)
										Console.WriteLine("\nData Tidak Ditemukan. ");
									else
									{
                                        Node TH;
                                        for (TH = current; TH != null; TH = TH.next)
                                        {
                                            Console.WriteLine("\nData Ditemukan ");
                                            Console.WriteLine("\nNomor Buku: " + current.noBuku);
                                            Console.WriteLine("\nJudul Buku : " + current.judulBuku);
                                            Console.WriteLine("\nTahun Terbit: " + current.tahunTerbit);
											Console.WriteLine("\nNama Pengarang: " + current.namaPengarang);
                                        }
                                    }
								}
								break;
							case '4':
								return;
							default:
								{
									Console.WriteLine("\nPilihan Tidak Valid");
									break;
								}	
						}
					}
					catch(Exception e)
					{
						Console.WriteLine("\nCheck Data Yang Anda Masukkan");
					}
				}
			}
		}
    }
}

// 2. (pake algoritma single Linked LIst karena lebih mudah aja di implemntasikan
//	  juga ada contoh nya waktu itu dikerjakan terus lebih cocok jadi milih algoritma single linked list

// 3. (Insert dan traverse)

// 4. Algoritma Queue merupakan struktur data dimana satu data dapat ditambahkan diakhir 
//	  disebut (rear) dan data dihapus dari yang paling terkahir disebut (front)?

// 5.	a. 5
//		b.lewat subpohon kiri dulu, terus kunjungi root. setelah itu lintasi subpohon kanan (1, 5, 8, 10, 12, 15, 20, 22, 25, 36, 38, 40, 45, 48, 50)
//		Untuk Preorder, harus di root dulu, lalu lintasi subpohon kiri, terus lanjut subpohon kanan.
//		Untuk Postorder, sama seperti Inorder, dengan lewat subpohon sebelah kiri dulu,
//		setelah itu lanjut lewat subpohon sebelah kanan. abis itu di root