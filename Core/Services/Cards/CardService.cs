using Data.Dtos.Cards;
using Data.Interfaces;
using Data.Models;
using Mapster;

namespace Core.Services.Cards
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardColumnRepository)
        {
            _cardRepository = cardColumnRepository;
        }
        public async Task<GetCardResponse?> UpdateCard(UpdateCardRequest cardUpdate)
        {
            Card? card = await _cardRepository.GetByIdAsync(cardUpdate.IdCard);
            if (card == null) return null;

            if (card.Order != cardUpdate.Order || card.IdColumn != cardUpdate.IdColumn)
            {
                if (card.IdColumn != cardUpdate.IdColumn)
                {
                    List<Card> cardsInOriginalColumn = await _cardRepository.GetByIdColumna(card.IdColumn);
                    var originalColumnCards = cardsInOriginalColumn.Where(c => c.IdCard != card.IdCard)
                                                                 .OrderBy(c => c.Order)
                                                                 .ToList();

                    for (int i = 0; i < originalColumnCards.Count; i++)
                    {
                        originalColumnCards[i].Order = i + 1;
                        await _cardRepository.UpdateAsync(originalColumnCards[i]);
                    }

                    List<Card> cardsInDestColumn = await _cardRepository.GetByIdColumna(cardUpdate.IdColumn);

                    int newOrder = Math.Min(Math.Max(1, cardUpdate.Order), cardsInDestColumn.Count + 1);

                    foreach (var destCard in cardsInDestColumn.OrderByDescending(c => c.Order))
                    {
                        if (destCard.Order >= newOrder)
                        {
                            destCard.Order += 1;
                            await _cardRepository.UpdateAsync(destCard);
                        }
                    }

                    cardUpdate.Order = newOrder;
                }
                else
                {
                    List<Card> cardsInColumn = await _cardRepository.GetByIdColumna(card.IdColumn);

                    var otherCards = cardsInColumn.Where(c => c.IdCard != card.IdCard).ToList();

                    int oldOrder = card.Order;
                    int newOrder = Math.Min(Math.Max(1, cardUpdate.Order), otherCards.Count + 1);

                    foreach (var otherCard in otherCards)
                    {
                        if (oldOrder < newOrder)
                        {
                            if (otherCard.Order > oldOrder && otherCard.Order <= newOrder)
                            {
                                otherCard.Order -= 1;
                                await _cardRepository.UpdateAsync(otherCard);
                            }
                        }
                        else if (oldOrder > newOrder)
                        {
                            if (otherCard.Order >= newOrder && otherCard.Order < oldOrder)
                            {
                                otherCard.Order += 1;
                                await _cardRepository.UpdateAsync(otherCard);
                            }
                        }
                    }

                    cardUpdate.Order = newOrder;
                }
            }

            card.Title = cardUpdate.Title;
            card.Description = cardUpdate.Description;
            card.IdColumn = cardUpdate.IdColumn;
            card.Order = cardUpdate.Order;

            await _cardRepository.UpdateAsync(card);
            return card.Adapt<GetCardResponse>();
        }


        public async Task<GetCardResponse> AddCard(AddCardRequest card)
        {
            List<Card> existingCards = await _cardRepository.GetByIdColumna(card.IdColumn);

            card.Order = existingCards.Count > 0 ? existingCards.Max(c => c.Order) + 1 : 1;

            Card newCard = card.Adapt<Card>();
            await _cardRepository.AddAsync(newCard);

            return newCard.Adapt<GetCardResponse>();
        }
    }
}
