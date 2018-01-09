using System;

namespace CorePortfolio3Final
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			//Room
			double RoomWidth = 0;
			double RoomLength = 0;
			double ShorterRoomSide = 0;
			double LongerRoomSide = 0;
			double CeilingArea = 0;
			double TotalPaintableWallArea = 0;
			//Window
			double WindowWidth = 0;
			double WindowHeight = 0;
			double WindowCasing = 0;

            //variables for array
            Window[] Windows=null;
			int NumberOfWindows=0;
			double totalWindowArea = 0;
			double totalWindowPerimeter = 0;

			//Door
			double DoorWidth = 0;
			double DoorHeight = 0;
			double DoorCasing = 0;
			//Closet
			double ClosetWidth = 0;
			double ClosetHeight = 0;
			double ClosetCasing = 0;
			//Paint

			string PaintName = " ";
			int PaintGrade = 0;
			double PaintPrice = 0;
			double TotalPaintPrice = 0;
			double TotalPaintGallons = 0;
			//Flooring
			double FlooringArea = 0;
			double TotalFlooringPrice = 0;
			string FlooringName = "";
			int Flooring = 0;
			double FlooringPrice = 0;
			//Casing
			const double WasteFactor = 0.10d;
			double CasingPrice = 0;
			double TotalCasing = 0;
			double TotalCasingPrice = 0;
			//Baseboard
			double BaseboardPrice = 0;
			double TotalBaseboard = 0;
			double TotalBaseboardPrice = 0;
			const double RoomHeight = 8;

			const double GSTRate = 0.05d;
			double NetTotal = 0;
			double TotalGST = 0;
			double Total = 0;
			string InputString = "";
			int UserChoice = 0;
			bool menu = int.TryParse(InputString, out UserChoice);

			do
			{
				//Menu-- I used a method to display my menu.
				UserChoice = getSafeInt();

				try
				{
					//SWITCH for which part of the room
					//user wants to enter input
					switch (UserChoice)
					{
						case 1:
							{
                                RoomWidth = 0;
                                RoomLength = 0;

								Console.Clear();
								Console.WriteLine("Room");
								RoomWidth = getSafeDouble("\tWidth");
								RoomLength = getSafeDouble("\tLength");
								break;
							}
						case 2:
							{
                              
                                Console.Clear();
                                Console.Write("You can add up to 3 windows.\n");
                                NumberOfWindows = ValidWindows("How many windows would you like to add?");
								Windows = new Window[NumberOfWindows];


								for (int i = 0; i < NumberOfWindows; i++)
								{

                                    Console.WriteLine("Window {0}: ", i + 1);
									WindowWidth = getSafeDouble("\tWidth");
									WindowHeight = getSafeDouble("\tHeight");
									Windows[i] = new Window(WindowWidth, WindowHeight);
									  
								}

								break;
							}
						case 3:
							{
                                DoorHeight = 0;
                                DoorWidth = 0;
                                
                                Console.Clear();
								Console.WriteLine("Door");
								DoorWidth = getSafeDouble("\tWidth");
								DoorHeight = getSafeDouble("\tHeight");

								break;
							}
						case 4:
							{
                                ClosetHeight = 0;
                                ClosetWidth = 0;
                                Console.Clear();
								Console.WriteLine("Closet");
								ClosetWidth = getSafeDouble("\tWidth");
								ClosetHeight = getSafeDouble("\tHeight");
								break;
							}
						case 5:
							{
								Console.Clear();
								Console.WriteLine("Paint");
								Console.WriteLine("\t1. Basic 29.99/ gallon");
								Console.WriteLine("\t2. Deluxe 39.99/ gallon");
								Console.WriteLine("\t3. Premium 49.99/ gallon");
								PaintGrade = ValidPaint("\t\tChoose your paint grade");

							}
							break;

						case 6:
							{
								Console.Clear();
								Console.WriteLine("Flooring");
								Console.WriteLine("\t1. Carpet/ 2.75^ft");
								Console.WriteLine("\t2. Tile/3.50^ft");
								Console.WriteLine("\t3. Hardwood/ 4.85^ft");
								Flooring = ValidFlooring("\t\tChoose your flooring");

								break;
							}
						case 7:
							{
								Console.Clear();
								CasingPrice = getSafeDouble("Casing Price");

								break;
							}
						case 8:
							{
								Console.Clear();
								BaseboardPrice = getSafeDouble("Baseboard Price");


								break;
							}
						case 9:
							{
								Console.Clear();

                                for (int i = 0; i < NumberOfWindows; i++)
                                {

                                    totalWindowPerimeter=0;
                                    totalWindowArea=0;

                                    totalWindowPerimeter += Windows[i].Perimeter();
									totalWindowArea += Windows[i].Area();

                                
                                }

                                //Room
                                ShorterRoomSide = (RoomHeight * RoomWidth);
								LongerRoomSide = (RoomLength * RoomHeight);
								TotalPaintableWallArea = (LongerRoomSide + ShorterRoomSide) + (LongerRoomSide - (ClosetHeight * ClosetWidth)) + (ShorterRoomSide - ((DoorHeight * DoorWidth) + (totalWindowArea)));

								//Ceiling and Flooring
								CeilingArea = (RoomLength * RoomWidth);
								FlooringArea = (RoomLength * RoomWidth);

								//paint
								TotalPaintPrice = CalculatePaintCost(PaintGrade, TotalPaintableWallArea, CeilingArea);

								if (PaintGrade == 1)
								{
									PaintName = "Basic";
									PaintPrice = 29.99;
									TotalPaintGallons = (TotalPaintableWallArea / 300) + (CeilingArea / 200);
								}
								else if (PaintGrade == 2)
								{
									PaintName = "Deluxe";
									PaintPrice = 39.99;
									TotalPaintGallons = (TotalPaintableWallArea / 400) + (CeilingArea / 250);

								}
								else if (PaintGrade == 3)
								{
									PaintName = "Premium";
									PaintPrice = 49.99;
									TotalPaintGallons = (TotalPaintableWallArea / 500) + (CeilingArea / 300);

								}
								else
								{
									PaintName = "Paint";
									PaintPrice = 0.00;
									TotalPaintGallons = 0;
								}

								//flooring


								if (Flooring == 1)
								{
									FlooringName = "Carpet";
									FlooringPrice = 2.75;
								}
								else if (Flooring == 2)
								{
									FlooringName = "Tile";
									FlooringPrice = 3.05;
								}
								else if (Flooring == 3)
								{
									FlooringName = "Hardwood";
									FlooringPrice = 4.85;
								}
								else
								{
									FlooringName = "Flooring";
									FlooringPrice = 0.00;
									FlooringArea = 0;
								}

								TotalFlooringPrice = CalculateFlooringCost(Flooring, FlooringArea);


								//Casing
								if (CasingPrice <=0)
								{
									TotalCasing = 0;
								}
								else
								{
                                   
 
									WindowCasing = (totalWindowPerimeter) + (totalWindowPerimeter * WasteFactor);
									DoorCasing = (DoorHeight * 2 + DoorWidth) + ((DoorHeight * 2 + DoorWidth) * WasteFactor);
									ClosetCasing = (ClosetHeight * 2 + ClosetWidth) + ((ClosetHeight * 2 + ClosetWidth) * WasteFactor);
									TotalCasing = WindowCasing + DoorCasing + ClosetCasing;
									TotalCasingPrice = CalculateCasingCost(CasingPrice, TotalCasing);
								}

                               
                                //Baseboards
                                if (BaseboardPrice <=0)
								{
									TotalBaseboard = 0;

								}
								else
								{
									TotalBaseboard = ((RoomLength - ClosetWidth) + (RoomWidth - DoorWidth) + (RoomLength + RoomWidth)) + (((RoomLength - ClosetWidth) + (RoomWidth - DoorWidth) + (RoomLength + RoomWidth)) * WasteFactor);
									TotalBaseboardPrice = CalculateBaseboardCost(BaseboardPrice, TotalBaseboard);
								}


								//Total
								NetTotal = TotalPaintPrice + TotalFlooringPrice + TotalCasingPrice + TotalBaseboardPrice;
								TotalGST = NetTotal * GSTRate;
								Total = NetTotal + TotalGST;



								//Packing Slip

								Console.WriteLine("\tPacking Slip");
								Console.WriteLine("***************************************");

								Console.WriteLine("{0,8}{1,-6}{2,-22}", TotalPaintableWallArea, " ^ft.", "Paintable Wall area");
								Console.WriteLine("{0,8}{1,-6}{2,-22} \n\n", CeilingArea, " ^ft.", "CeilingArea");

								Console.WriteLine("{0, 8}{1,-10}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", Math.Ceiling(TotalPaintGallons), " gallon(s) ", PaintName, "@", PaintPrice, " =", TotalPaintPrice);
								Console.WriteLine("{0, 8}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", FlooringArea, " ^ft.", FlooringName, "@", FlooringPrice, " =", TotalFlooringPrice);
								Console.WriteLine("{0, 8:0.00}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", TotalCasing, " ^ft.", "Casing", "@", CasingPrice, " =", TotalCasingPrice);
								Console.WriteLine("{0, 8:0.00}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", TotalBaseboard, " ^ft.", "Baseboard", "@", BaseboardPrice, " =", TotalBaseboardPrice);
								Console.WriteLine("{0, 8}{1,11}{2,22}{3,1}{4,8}{5,1}{6,8:0.00}", "", "", "", "", "", "", "  =======");
								Console.WriteLine("{0, 8:0.00}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", "", "", "", "", "Net Total", "=", NetTotal);
								Console.WriteLine("{0, 8:0.00}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", "", "", "", "", " GST", " =", TotalGST);
								Console.WriteLine("{0, 8:0.00}{1,-11}{2,-22}{3,1}{4,8:0.00}{5,1}{6,8:0.00}", "", "", "", "", " Total", " =", Total);


                                break;
							}
						default:
							{

								break;
							}

					}

				}
				catch (Exception ex)
				{

					Console.WriteLine(ex.Message);
				}


			} while (UserChoice != 0);

			Console.Clear();
			Console.Write("Thank you for using RenoCalc. Any key to Exit.");
			Console.ReadKey();

		}//end of main

		static int getSafeInt()
		{
			string inputString = "";
			int ValidUserChoice = 0;
			bool validflag = false;
			while (!validflag)
			{

				try
				{

					Console.WriteLine("1. Room Size");
					Console.WriteLine("2. Window Size");
					Console.WriteLine("3. Door Size");
					Console.WriteLine("4. Closet Size");
					Console.WriteLine("5. Paint Type");
					Console.WriteLine("6. Flooring Type");
					Console.WriteLine("7. Casing Price");
					Console.WriteLine("8. Baseboard Price");
					Console.WriteLine("9. Create Packing Slip");
					Console.WriteLine("0. Exit");
					Console.Write("\t Make a selection >>");
					inputString = Console.ReadLine();


					//Checks if input is NUMERIC
					if (int.TryParse(inputString, out ValidUserChoice))
					{
						//Checks if the string is an INT numeric
						if (ValidUserChoice <= 9 && ValidUserChoice >= 0)
						{
							//Valid flag is true so it stops the loop
							validflag = true;
						}
						else
						{
							Console.Clear();
							throw new Exception(string.Format("Invalid choice-please select from 0-9"));
						}
					}
					else
					{
						//the string was NOT a numeric
						Console.Clear();
						throw new Exception(string.Format("Invalid choice-please select from 0-9"));
					}
				}
				catch (Exception ex)
				{

					Console.WriteLine(ex.Message);
				}

			}//eol data input validation
			return ValidUserChoice;
		}//end of Menu method

		//Menu for validating if mesurements entered
		//in the SWITCH (UserChoice) is valid.
		static double getSafeDouble(string prompt)
		{
			string inputString = "";
			double ValidNumber = 0;
			bool validflag = false;
			while (!validflag)
			{
				try
				{

					Console.Write("{0}:\t", prompt);
					inputString = Console.ReadLine();

					//reads if input is a double numeric
					if (double.TryParse(inputString, out ValidNumber))
					{
						if (ValidNumber > 0)
						{
							//stops the loop 
							validflag = true;
						}
						else
						{
							//display error message if input is less than 0
							Console.WriteLine("Invalid input...try again.");

						}
					}
					else
					{
						//the string was NOT a numeric

						throw new Exception(string.Format("Invalid input...try again."));
					}
				}


				catch (Exception ex)
				{
					//handles aborts
					//ex points to the error
					//.Message is the details of the error
					Console.WriteLine(ex.Message);
				}


			}
			return ValidNumber;
		}//END OF METHOD

		//calculates casing cost
		static double CalculateCasingCost(double CasingPrice, double CasingLength)
		{
			double TotalCasingPrice = 0;

			TotalCasingPrice = CasingPrice * CasingLength;

			return TotalCasingPrice;
		}

		//calculates baseboardcost
		static double CalculateBaseboardCost(double BaseboardPrice, double BaseboardLength)
		{
			double TotalBaseboardCost = 0;

			TotalBaseboardCost = BaseboardPrice * BaseboardLength;

			return TotalBaseboardCost;
		}

      

		//calculates paint cost
		static double CalculatePaintCost(int PaintType, double WallArea, double CeilingArea)
		{
			double PaintPrice = 0;
			double TotalPaintGallons = 0;
			double TotalPaintPrice = 0;

			switch (PaintType)
			{

				case 1:
					{

						PaintPrice = 29.99d;
						TotalPaintGallons = (WallArea / 300) + (CeilingArea / 200);
						TotalPaintPrice = ((Math.Ceiling(TotalPaintGallons)) * PaintPrice);
						break;
					}
				case 2:
					{

						PaintPrice = 39.99d;
						TotalPaintGallons = (WallArea / 400) + (CeilingArea / 250);
						TotalPaintPrice = ((Math.Ceiling(TotalPaintGallons)) * PaintPrice);
						break;
					}
				case 3:
					{

						PaintPrice = 49.99d;
						TotalPaintGallons = (WallArea / 500) + (CeilingArea / 300);
						TotalPaintPrice = ((Math.Ceiling(TotalPaintGallons)) * PaintPrice);
						break;
					}
			}
			return TotalPaintPrice;
		}

		//calculates flooring cost
		static double CalculateFlooringCost(int FlooringType, double FloorArea)
		{

			double FlooringPrice = 0;
			double TotalFlooring = 0;
			double TotalFlooringPrice = 0;
			//Flooring Switch
			switch (FlooringType)
			{
				case 1:
					{

						FlooringPrice = 2.75d;
						TotalFlooring = FloorArea / 2.75d;
						TotalFlooringPrice = FloorArea * FlooringPrice;
						break;
					}
				case 2:
					{

						FlooringPrice = 3.50d;
						TotalFlooring = FloorArea / 3.50d;
						TotalFlooringPrice = FloorArea * FlooringPrice;
						break;
					}
				case 3:
					{

						FlooringPrice = 4.85d;
						TotalFlooring = FloorArea / 4.85d;
						TotalFlooringPrice = FloorArea * FlooringPrice;
						break;
					}
				default:
					{
						Console.WriteLine("Please enter a valid number");
						break;
					}

			} //end of flooring switch statement
			return TotalFlooringPrice;

		}

		//Method for validating input in the 
		//SWITCH for PaintGrade
		static int ValidPaint(string prompt)
		{
			string inputString = "";
			int ValidNumber = 0;
			bool validflag = false;
			while (!validflag)
			{
				try
				{
					Console.Write("{0}:\t", prompt);
					inputString = Console.ReadLine();

					if (int.TryParse(inputString, out ValidNumber))
					{
						if (ValidNumber > 0 && ValidNumber <= 3)
						{

							validflag = true;
						}
						else
						{

							throw new Exception(string.Format("****Invalid Paint Grade Choice******"));

						}
					}
					else
					{
						//the string was NOT a numeric

						throw new Exception(string.Format("****Invalid Paint Grade Choice******"));
					}
				}

				catch (Exception ex)
				{

					Console.WriteLine(ex.Message);
				}


			}//eol data input validation
			return ValidNumber;
		}//end of method

		 //validating number of windows
		static int ValidWindows(string prompt)
		{
			string inputString = "";
			int ValidNumber = 0;
			bool validflag = false;
			while (!validflag)
			{
				try
				{
					Console.Write("{0}\t", prompt);
					inputString = Console.ReadLine();

					if (int.TryParse(inputString, out ValidNumber))
					{
						if (ValidNumber > 0 && ValidNumber <= 3)
						{

							validflag = true;
						}
						else if(ValidNumber<=0)
						{
                            Console.Clear();
							throw new Exception(string.Format("****You cannot add less than 1 window.******\n"));

						}
                        else
                        {
                            Console.Clear();
                            throw new Exception(string.Format("****You cannot add more than 3 windows.******\n"));

                        }
                    }
					else
					{
                        //the string was NOT a numeric
                        Console.Clear();
                        throw new Exception(string.Format("****Invalid choice.******\n"));
					}
				}

				catch (Exception ex)
				{

					Console.WriteLine(ex.Message);
				}


			}//eol data input validation
			return ValidNumber;
		}//end of method


		//Method for checking valid input in
		//Flooring switch
		static int ValidFlooring(string prompt)
		{
			string inputString = "";
			int ValidNumber = 0;
			bool validflag = false;
			while (!validflag)
			{
				try
				{
					Console.Write("{0}:\t", prompt);
					inputString = Console.ReadLine();

					if (int.TryParse(inputString, out ValidNumber))
					{
						if (ValidNumber > 0 && ValidNumber <= 3)
						{

							validflag = true;
						}
						else
						{

							throw new Exception(string.Format("****Invalid Flooring Grade Choice******"));

						}
					}
					else
					{
						//the string was NOT a numeric

						throw new Exception(string.Format("****Invalid Flooring Grade Choice******"));
					}
				}

				catch (Exception ex)
				{

					Console.WriteLine(ex.Message);
				}


			}//eol data input validation
			return ValidNumber;
		}//end of method

		
    }
}
