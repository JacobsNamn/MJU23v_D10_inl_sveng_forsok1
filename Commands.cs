﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU23v_D10_inl_sveng {
    internal class Commands {
        public static void LoadCommand(string[] args) {
            // TODO: Innehållet av båda if:arna kan kombineras.
            if (args.Length == 2) {
                // TODO: Try/catch.
                using (StreamReader sr = new StreamReader(@"dict\" + args[1])) {
                    Program.Dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null) {
                        SweEngGloss gloss = new SweEngGloss(line);
                        Program.Dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            } else if (args.Length == 1) {
                // TODO: Try/catch.
                using (StreamReader sr = new StreamReader(Program.DefaultFile)) {
                    Program.Dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null) {
                        SweEngGloss gloss = new SweEngGloss(line);
                        Program.Dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        public static void ListCommand(string[] args) {
            foreach (SweEngGloss gloss in Program.Dictionary) {
                Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
            }
        }

        public static void NewCommand(string[] args) {
            if (args.Length == 3) {
                Program.Dictionary.Add(new SweEngGloss(args[1], args[2]));
            } else if (args.Length == 1) {
                Console.WriteLine("Write word in Swedish: ");
                string s = Console.ReadLine();
                Console.Write("Write word in English: ");
                string e = Console.ReadLine();
                Program.Dictionary.Add(new SweEngGloss(s, e));
            }
            // TODO: Lägg till fall där argsen är 2.
        }

        public static void DeleteCommand(string[] args) {
            if (args.Length == 3) {
                int index = -1;
                for (int i = 0; i < Program.Dictionary.Count; i++) { // TODO: Förkorta.
                    SweEngGloss gloss = Program.Dictionary[i];
                    if (gloss.word_swe == args[1] && gloss.word_eng == args[2])
                        index = i;
                }
                Program.Dictionary.RemoveAt(index);
            } else if (args.Length == 1) {
                // TODO: Kolla om listan är tom.
                Console.WriteLine("Write word in Swedish: ");
                string s = Console.ReadLine();
                Console.Write("Write word in English: ");
                string e = Console.ReadLine();
                int index = -1;
                for (int i = 0; i < Program.Dictionary.Count; i++) // TODO: Förkorta.
                {
                    SweEngGloss gloss = Program.Dictionary[i];
                    if (gloss.word_swe == s && gloss.word_eng == e)
                        index = i;
                }
                Program.Dictionary.RemoveAt(index); // FIXME: Checka om out-of-bounds först.
            }
        }

        public static void TranslateCommand(string[] args) {
            if (args.Length == 2) {
                foreach (SweEngGloss gloss in Program.Dictionary) {
                    if (gloss.word_swe == args[1])
                        Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                    if (gloss.word_eng == args[1])
                        Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                }
            } else if (args.Length == 1) {
                Console.WriteLine("Write word to be translated: ");
                string s = Console.ReadLine();
                foreach (SweEngGloss gloss in Program.Dictionary) {
                    if (gloss.word_swe == s)
                        Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                    if (gloss.word_eng == s)
                        Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                }
            }
        }
    }
}