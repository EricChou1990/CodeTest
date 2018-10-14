using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionicAntCodeTest
{
    public class BionicAntExperiment
    {
        private int _boundaryX;
        private int _boundaryY;
        private List<BionicAnt> _bionicantList = new List<BionicAnt>();
        private List<string> _resultList = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="boundaryXvalue"></param>
        /// <param name="boundaryYvalue"></param>
        /// <param name="positionAndAction"></param>
        public BionicAntExperiment(int boundaryXvalue, int boundaryYvalue, params string[] positionAndAction)
        {
            try
            {
                if (boundaryXvalue<=0 || boundaryYvalue<=0)
                {
                    throw new Exception("fail to initialize the postage stamp");
                }
                this._boundaryX = boundaryXvalue;
                this._boundaryY = boundaryYvalue;
                CreateList(positionAndAction);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }

        /// <summary>
        /// Create a list of ants' original location and command accodring to input
        /// </summary>
        /// <param name="positionAndAction"></param>
        public void CreateList(params string[] positionAndAction)
        {
            try
            {  
                if (positionAndAction.Length % 2 == 0)
                {
                    for (int i = 0; i < positionAndAction.Length - 1; i++)
                    {
                        BionicAnt tmpAnt = new BionicAnt();
                        string[] position = positionAndAction[i].Split(' ');
                        if (position.Length == 3)
                        {
                            //add x and y co-ordinates to list
                            tmpAnt.locationX = Convert.ToInt32(position[0]);
                            tmpAnt.locationY = Convert.ToInt32(position[1]);
                            if (tmpAnt.locationX>this._boundaryX || tmpAnt.locationY>this._boundaryY)
                            {
                                throw new Exception("Delopyment out of range");
                            }
                            tmpAnt.direction = position[2];
                        }
                        else
                        {
                            throw new Exception("original deployment data in wrong format");
                        }
                        i++;
                        //add orientation to list
                        tmpAnt.command = positionAndAction[i];
                        _bionicantList.Add(tmpAnt);
                    }
                }
                else
                {
                    throw new Exception("length of input data set should be a even number");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


        }

        /// <summary>
        /// Generate a list of ants' final location according to command
        /// </summary>
        /// <returns></returns>
        public List<string> GenerateResult()
        {
            try
            {
                 foreach (BionicAnt ant in _bionicantList)
                {                  
                    _resultList.Add(ExecuteCommand(ant));
                }               
                 return _resultList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Eexcute command to move ant
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        public string ExecuteCommand(BionicAnt ant)
        {
            try
            {
                int[] tmpXY;
                char[] antCommand = ant.command.ToCharArray();
                for (int i = 0; i < antCommand.Length; i++)
                {
                    Console.WriteLine(antCommand[i]);
                    if (antCommand[i] == 'L' || antCommand[i] == 'R')
                    {
                        ant.direction = Rotate(ant.direction, antCommand[i]);
                    }
                    else if (antCommand[i] == 'M')
                    {
                        tmpXY = Move(ant.locationX, ant.locationY, ant.direction);
                        ant.locationX = tmpXY[0];
                        ant.locationY = tmpXY[1];
                    }
                    else
                    {
                        throw new Exception("invalid command");
                    }
                }
           
                string[] result = new string[] { ant.locationX.ToString(), ant.locationY.ToString(), ant.direction };
                string resultString = string.Join(" ", result);
                return resultString;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        /// <summary>
        /// Rotate ant based its orientation and command
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public string Rotate(string direction, char rotation)
        {
            try
            {
                switch (direction)
                {
                    case "N":
                        if (rotation == 'L')
                        {
                            return "W";
                        }
                        else
                        {
                            return "E";
                        }

                    case "E":
                        if (rotation == 'L')
                        {
                            return "N";
                        }
                        else
                        {
                            return "S";
                        }

                    case "S":
                        if (rotation == 'L')
                        {
                            return "E";
                        }
                        else
                        {
                            return "W";
                        }

                    case "W":
                        if (rotation == 'L')
                        {
                            return "S";
                        }
                        else
                        {
                            return "N";
                        }

                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Move ant forward one grid point
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public int[] Move(int locationX, int locationY, string direction)
        {
            try
            {
                int[] tmpXY;

                switch (direction)
                {
                    case "N":
                        if (locationY < this._boundaryY)
                        {
                            locationY++;
                        }
                        else
                        {
                            locationY = this._boundaryY;
                        }
                        break;
                    case "E":
                        if (locationX < this._boundaryX)
                        {
                            locationX++;
                        }
                        else
                        {
                            locationX = this._boundaryX;
                        }
                        break;
                    case "S":
                        if (locationY > 0)
                        {
                            locationY--;
                        }
                        else
                        {
                            locationY = 0;
                        }
                        break;
                    case "W":
                        if (locationX > 0)
                        {
                            locationX--;
                        }
                        else
                        {
                            locationX = 0;
                        }
                        break;
                    default:
                        break;
                }
                tmpXY = new int[] { locationX, locationY };
                return tmpXY;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
