using Day11.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    public static class Tools
    {
        private const char SEAT = 'L';

        public static long GetResultPart1(string inputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var seats = Init(lines);

            bool valueChanged;
            var step = 0;
            do
            {
                valueChanged = false;
                var previous = seats.Select(a => a.ToArray()).ToArray();
                for (var i = 0; i < seats.Length; i++)
                {
                    for (var j = 0; j < seats[i].Length; j++)
                    {
                        if (!seats[i][j].HasSeat)
                        {
                            continue;
                        }

                        int occupied = GetNumberOfOccupiedAdjustedSeats(i, j, previous);
                        var next = NextStep(previous[i][j], occupied, out var changed);
                        seats[i][j] = next;
                        if (changed)
                        {
                            valueChanged = true;
                        }
                    }
                }

                if (step > 9999)
                {
                    throw new Exception("Infinite loop!");
                }

                step++;
            } while (valueChanged);

            return GetTotalOccupiedNumber(seats);
        }

        private static int GetNumberOfOccupiedAdjustedSeats(int i, int j, Place[][] seats)
        {
            var occupiedValues = new List<bool?>
            {
                seats.ElementAtOrDefault(i - 1)?.ElementAtOrDefault(j - 1)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i - 1)?.ElementAtOrDefault(j)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i - 1)?.ElementAtOrDefault(j + 1)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i)?.ElementAtOrDefault(j - 1)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i)?.ElementAtOrDefault(j + 1)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i + 1)?.ElementAtOrDefault(j - 1)?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i + 1)?.ElementAtOrDefault(j )?.HasOccupiedSeat,
                seats.ElementAtOrDefault(i + 1)?.ElementAtOrDefault(j + 1)?.HasOccupiedSeat
            };

            return occupiedValues.Count(x => x.HasValue && x.Value);
        }

        private static int GetTotalOccupiedNumber(Place[][] seats)
        {
            var totalOccupiedNumber = 0;
            seats.ToList().ForEach(x => x.ToList().ForEach(y =>
            {
                if (y.HasSeat && y.IsOccupied)
                {
                    totalOccupiedNumber++;
                }
            }));
            return totalOccupiedNumber;
        }
        
        private static Place[][] Init(string[] lines)
        {
            var seats = new Place[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].ToCharArray();
                seats[i] = new Place[line.Length];
                for (var j = 0; j < line.Length; j++)
                {
                    seats[i][j] = new Place(line[j] == SEAT);
                }
            }

            return seats;
        }

        private static Place NextStep(Place current, int occupied, out bool changed)
        {
            changed = false;
            if (!current.HasSeat) return new Place(false);

            var next = new Place(true) { IsOccupied = current.IsOccupied };

            switch (current.IsOccupied)
            {
                case true when occupied >= 4:
                    next.IsOccupied = false;
                    changed = true;
                    break;
                case false when occupied == 0:
                    next.IsOccupied = true;
                    changed = true;
                    break;
            }

            return next;
        }
    }
}