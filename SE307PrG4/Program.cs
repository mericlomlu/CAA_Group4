﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SE307PrG4
{
    class Program
    {
        // SE307 GR4 PROJECT 'Cooking Advisor' PROGRAM EXPLANATION
        // Main program is used as a monitor for Menus and Sub menus
        // Write to Disk and Display functions are handled by the Class InOut
        // Kitchen Menu Items are separated ın 6 Categories for ease of use
        // All 6 categories are descended from the abstract superclass Kitchen

        static void Main()
        {
            InOut In1 = new InOut(); // Dummy InOut object for input output operations
            string key, key1, ns, CurrentC = "Pasta"; // Set Current category string to Pasta
            int Isel = 1, Itry;

            for(int i=1; i < 7; i++)  In1.ReadList(i); //Load List array for all cats. from disk
            bool lp = true;
            while (lp)
            {
                // Main menu selection
                //
                Console.WriteLine("------ IUE(CE) - SE307 GR4 Project MAIN KITCHEN MENU ------\n" +
                             "___________________________________________________________\n" +
                             "Selected Category: " + CurrentC + " -  Menu Items" + "\n" +
                             "___________________________________________________________\n" +
                             "    0 - Exit Program\n" +
                             "    1 - Change Category Selection\n" +
                             "    2 - Display A Menu from Current Category\n" +
                             "    3 - Menu Display with Options Submenu\n" +
                             "    4 - Add a Menu to Current Category\n" +
                             "    5 - Edit a Menu Item from Current Category\n" +
                             "    6 - Delete a Menu from Current Category\n" +
                             "    7 - Clear Copmlete Current Category Records\n" +
                             "    8 - Save Changes to Disk File for Current Category\n" +
                             "    9 - Load Data From Disk csv Files");

                while ((key = In1.GetKeyb(0, 9, "Main Menu Choice")) == null) { continue; }

                switch (key)
                {
                    // Exit program
                    //
                    case "0": lp = false; break;
                    // Set category setting
                    //
                    case "1":
                        Console.WriteLine("________________________________________\n" +
                                          "------ CATEGORY SELECTION SUBMENU ------\n" +
                                          "________________________________________\n" +
                                          "    0 - Return to Main Menu\n"+
                                          "    1 - Pasta\n" +
                                          "    2 - Meat & Fish\n" +
                                          "    3 - Olive Oils\n" +
                                          "    4 - Salads\n" +
                                          "    5 - Desserts\n" +
                                          "    6 - Soups");

                        while ((key1 = In1.GetKeyb(0, 6, "Category Choice")) == null) { continue; }

                        switch (key1)
                        {
                            case "0": break;
                            case "1":
                                In1.SetOutPath("Pasta.csv");
                                CurrentC = "Pasta";
                                Isel = int.Parse(key1);
                                break;

                            case "2":
                                In1.SetOutPath("MeatFish.csv");
                                CurrentC = "MeatFish";
                                Isel = int.Parse(key1);
                                break;

                            case "3":
                                In1.SetOutPath("OliveOil.csv");
                                CurrentC = "OliveOil";
                                Isel = int.Parse(key1);
                                break;

                            case "4":
                                In1.SetOutPath("Salad.csv");
                                CurrentC = "OliveOil";
                                Isel = int.Parse(key1);
                                break;

                            case "5":
                                In1.SetOutPath("Dessert.csv");
                                CurrentC = "Salad";
                                Isel = int.Parse(key1);
                                break;

                            case "6":
                                In1.SetOutPath("Soup.csv");
                                CurrentC = "Dessert";
                                Isel = int.Parse(key1);
                                break;

                            default: break;
                        }
                        Console.WriteLine("Category: " + CurrentC + "DiskPath: " +
                                                                    In1.GetOutPath());
                        break;
                    // Menu Addition
                    //
                    case "2":
                        In1.DisplayAll(Isel, 0, null, CurrentC);
                        Console.WriteLine("Enter Menu No. to Display: ");
                        if ((Itry = In1.GetKeyb()) == -1000) goto case "2";
                        if (Itry == 0) break;
                        switch (Isel)
                        {
                            case 1: if(Itry <= In1.Pastas.Count)In1.Pastas[Itry - 1].SetRecipe(-1); break;
                            case 2: if (Itry <= In1.MeatFishs.Count) In1.MeatFishs[Itry - 1].SetRecipe(-1); break;
                            case 3: if (Itry <= In1.OliveOils.Count) In1.OliveOils[Itry - 1].SetRecipe(-1); break;
                            case 4: if (Itry <= In1.Salads.Count) In1.Salads[Itry - 1].SetRecipe(-1); break;
                            case 5: if (Itry <= In1.Desserts.Count) In1.Desserts[Itry - 1].SetRecipe(-1); break;
                            case 6: if (Itry <= In1.Soups.Count) In1.Soups[Itry - 1].SetRecipe(-1); break;
                            default: break;
                        }
                        break;
                        //Display menu items with selectable options
                        //

                    case "3":
                        Console.WriteLine("________________________________________\n" +
                           "------ SELECT DISPLAY FORMS FOR ITEM(S) ------\n" +
                           "________________________________________\n" +
                           "    0 - Return to Main Menu\n" +
                           "    1 - Display All Menu İtems In Current Category\n" +
                           "    2 - Display All Menu Items of All Categories\n" +
                           "    3 - Display Item by Menu Name\n" +
                           "    4 - Display Item by Ingredient Content\n" +
                           "    5 - Display All Menu Items by Calorie Limit\n" +
                           "    6 - Display All Menu Items by Cooking Time Limit");

                        while ((key1 = In1.GetKeyb(0, 6, "Display Choice")) == null) { continue; }

                        switch (key1)
                        {
                            case "0": break; // exit to main
                            case "1": In1.DisplayAll(Isel, 0, null, CurrentC);break;//All menus
                            case "2": //Category menus
                                Console.WriteLine("___________ COMPLETE MENU LISTING ____________\n");
                                for (int i = 1; i < 7; i++) In1.DisplayAll(i, 0, null, CurrentC);
                                break;

                            case "3": // Recipe display (current cat.)
                                Console.WriteLine("Please Enter Recipe Name");
                                ns = Console.ReadLine();
                                In1.DisplayAll(Isel, 1, ns, CurrentC);
                                break;

                            case "4": // Display by ingredient search (current cat.)
                                Console.WriteLine("Please Enter Ingredient Name");
                                ns = Console.ReadLine();
                                In1.DisplayAll(Isel, 2, ns, CurrentC);
                                break;

                            case "5": // Display by calorie rating (current cat.)
                                Console.WriteLine("Please Enter Calorie Limit");
                                if ((Itry = In1.GetKeyb()) == -1000) goto case "5";
                                In1.DisplayAll(Isel, 3, Itry.ToString(), CurrentC);
                                break;

                            case "6": //Display by cooking time rating (current cat.)
                                Console.WriteLine("Please Enter Cooking Time Limit");
                                if ((Itry = In1.GetKeyb()) == -1000) goto case "6";
                                In1.DisplayAll(Isel, 4, Itry.ToString(), CurrentC);
                                break;

                            default: break;
                        }
                        break;

                    case "4": // Add menu item (Current cat.)
                        In1.AddMenuItem(Isel);
                        break;

                    case "5": //Edit a menu item (Current cat.)
                        Inval:
                        In1.DisplayAll(Isel, 0, null, CurrentC);
                        Console.WriteLine("Enter Menu No. to Edit: ");
                        if ((Itry = In1.GetKeyb()) == -1000) goto case "5";
                        if (Itry == 0) break;
                        Itry--; if(Itry < 0 ) { Console.WriteLine("Error"); goto Inval; }
                        switch(Isel)
                        {
                            case 1: if (Itry >= In1.Pastas.Count) goto default;break;                                      
                            case 2: if (Itry >= In1.MeatFishs.Count) goto default; break;
                            case 3: if (Itry >= In1.OliveOils.Count) goto default; break;
                            case 4: if (Itry >= In1.Salads.Count) goto default; break;
                            case 5: if (Itry >= In1.Desserts.Count) goto default; break;
                            case 6: if (Itry >= In1.Soups.Count) goto default; break;
                            default: Console.WriteLine("Error"); goto Inval;
                        } // Selection of Menu attribute to edit
                        Console.WriteLine("________________________________________\n" +
                           " MENU ITEM EDIT PARAMETER SELECTION -\n" +
                           "________________________________________\n" +
                           "    0 - Return to Main Menu\n" +
                           "    1 - Edit Name\n" +
                           "    2 - Edit Ingredients\n" +
                           "    3 - Edit Calorie Rating\n" +
                           "    4 - Edit Coking Instructions\n" +
                           "    5 - Edit Cooking Time");
                        while ((key1 = In1.GetKeyb(0, 5, "Parameter Choice")) == null) { continue; }
                        int nkey = int.Parse(key1);
                        if (nkey == 0) break;
                        switch (Isel)
                        {
                            case 1: In1.Pastas[Itry].SetRecipe(nkey); break;
                            case 2: In1.MeatFishs[Itry].SetRecipe(nkey); break;
                            case 3: In1.OliveOils[Itry].SetRecipe(nkey); break;
                            case 4: In1.Salads[Itry].SetRecipe(nkey); break;
                            case 5: In1.Desserts[Itry].SetRecipe(nkey); break;
                            case 6: In1.Soups[Itry].SetRecipe(nkey); break;
                            default: break;
                        }
                        break;

                    case "6": // Delete menu item (Current cat.)
                        In1.DisplayAll(Isel, 0, null, CurrentC);
                        Console.WriteLine("Enter Menu No. to DELETE: ");
                        if ((Itry = In1.GetKeyb()) == -1000) goto case "6";
                        switch (Isel)
                        {
                            case 1: In1.Pastas.RemoveAt(Itry - 1); break;
                            case 2: In1.MeatFishs.RemoveAt(Itry-1); break;
                            case 3: In1.OliveOils.RemoveAt(Itry-1); break;
                            case 4: In1.Salads.RemoveAt(Itry-1); break;
                            case 5: In1.Desserts.RemoveAt(Itry-1); break;
                            case 6: In1.Soups.RemoveAt(Itry-1); break;
                            default: break;
                        }
                        break;

                    case "7": // Clear current category List array
                        switch(Isel)
                        {
                            case 1:In1.Pastas.Clear(); break;
                            case 2:In1.MeatFishs.Clear(); break;
                            case 3: In1.OliveOils.Clear(); break;
                            case 4: In1.Salads.Clear(); break;
                            case 5: In1.Desserts.Clear(); break;
                            case 6: In1.Soups.Clear(); break;
                            default: break;
                        }
                        break;

                    case "8": //Write current Category List array to disk
                        In1.WriteList(Isel);
                        break;

                    case "9"://Read all Category List arrays from disk (reload)
                        for (int i = 1; i < 7; i++) In1.ReadList(i);
                        break;
                    default: break;

                }

            }
            Console.WriteLine("Program Ended By User - Hit Any key To Exit");
            Console.ReadLine(); //End of program
        }
    }
}