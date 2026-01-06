using Proiect_POO.Entities;
using Proiect_POO.ValueObjects;

namespace Proiect_POO.Aggregates;

public sealed class Campaign
{
    private readonly List<Donation> _donations;
    public CampaignId Id { get;}
    public string Title { get; private set; }
    public decimal TargetAmount { get; }
    public bool IsActive { get; private set; } = true;

    public Campaign(CampaignId id, string title, decimal targetAmount)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
    }

    public void AddDonation(Donation donation)
    {
        if(!IsActive)
             throw new InvalidOperationException("Campaign is not active");
        _donations.Add(donation);
        if(GetCurrentAmount()>=TargetAmount)
            IsActive = false; //inchid campania daca s-a atins targetul
    }

    public decimal GetCurrentAmount() => _donations.Select(d => d.Amount.Amount).Sum();
}