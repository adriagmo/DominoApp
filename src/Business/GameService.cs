using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public interface IGameService
    {
        List<GameDto> ResultDomino(List<GameDto> Order, List<GameDto> model);
        string ValidateNumberPairs(int pairs);
        List<GameDto> ListPairs(List<GameDto> model);
        GameDto Exchange(int num1, int num2);
    }
    public class GameService : IGameService
    {
        public List<GameDto> ResultDomino(List<GameDto> OrderPairs, List<GameDto> listModel)
        {
            try
            {
                for (int i = 0; i < listModel.Count; ++i)
                {
                    GameDto dto = listModel[i];
                    GameDto dtoReverse = Exchange(dto.N1, dto.N2);
                    List<GameDto> newOrder = new List<GameDto>();
                    if (OrderPairs.Count == 0)
                    {
                        OrderPairs.Add(dto);
                        listModel.RemoveAt(i);
                        ResultDomino(OrderPairs, listModel);
                    }
                    else if ( OrderPairs.Last().N2 == dto?.N1)
                    {
                        OrderPairs.Add(dto);
                        listModel.RemoveAt(i);
                        ResultDomino(OrderPairs, listModel);
                    }
                    else if (OrderPairs.Last().N2 == dtoReverse?.N1)
                    {
                        OrderPairs.Add(dtoReverse);
                        listModel.RemoveAt(i);
                        ResultDomino(OrderPairs, listModel);
                    }
                }

                return OrderPairs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ValidateNumberPairs(int pairs)
        {
            if (pairs <= 0)
            {
                return "Se requiere Mínimo 2 fichas";
            }
            else if (pairs < 2)
            {
                return "Se requiere Mínimo 2 fichas";
            }
            else if (pairs > 6)
            {
                return "Las fichas maximas permitidas son 6";
            }

            return null;
        }

        public List<GameDto> ListPairs(List<GameDto> model)
        {
            return ResultDomino(new List<GameDto>(), model);
        }

        public GameDto Exchange(int num1, int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;

            return new GameDto() { N1 = num1, N2 = num2 };
        }
    }
}

