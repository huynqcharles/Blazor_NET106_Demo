using Microsoft.AspNetCore.Components;
using NET106_Demo_BlazorServer.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.Pages
{
    public class FootballPlayerDetailBase : ComponentBase
    {
        [Inject]
        public IFootballPlayerService FootballPlayerService { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        [Inject]
        public IPositionService PositionService { get; set; }
        public Position Position { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FootballPlayer = await FootballPlayerService.GetFootballPlayer(int.Parse(Id));

            Position = await PositionService.GetPosition(FootballPlayer.PositionId);
        }
    }
}
