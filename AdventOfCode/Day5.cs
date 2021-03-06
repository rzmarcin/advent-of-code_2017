﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {
    public class Day5 : IDay {
        public string Name => "--- Day 5: A Maze of Twisty Trampolines, All Alike ---";

        void Run() {
            string[] examples = new string[] {
                "0 3 0 1 -3",
            };
            foreach (string example in examples) {
                Console.WriteLine(string.Format("Example data, steps: {0}", Process(example)));
            }
            Console.WriteLine("Test data, steps: {0}", Process(TestData.DATA5));


            foreach (string example in examples) {
                Console.WriteLine(string.Format("Example data, steps (decr): {0}", Process(example, true)));
            }
            Console.WriteLine("Test data, steps (decr): {0}", Process(TestData.DATA5, true));
        }

        int Process(string input, bool allowDecrement = false) {
            int[] commands = input.Split(' ')
                .Select(i => int.Parse(i)).ToArray();

            int steps = 0;
            for (int i = 0; i >= 0 && i < commands.Length;) {
                steps++;
                int jumpTo = commands[i] + i;
                if (allowDecrement) {
                    if (commands[i] >= 3) {
                        commands[i]--;
                    } else {
                        commands[i]++;
                    }
                } else {
                    commands[i]++;
                }
                if (jumpTo >= commands.Length || jumpTo < 0) {
                    return steps;
                }
                i = jumpTo;
            }
            return 0;
        }

        public void Print() {
            Run();
        }
    }
}
