using Microsoft.AspNetCore.Components;
using NET106_Demo_BlazorServer.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.Pages
{
    public class EditFootballPlayerBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IFootballPlayerService FootballPlayerService { get; set; }
        public FootballPlayer FootballPlayer { get; set; } = new FootballPlayer();

        [Inject]
        public IPositionService PositionService { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            FootballPlayer = await FootballPlayerService.GetFootballPlayer(int.Parse(Id));

            Positions = (await PositionService.GetPositions()).ToList();
        }

        protected async Task HandleSubmitForm()
        {
            FootballPlayer result = null;

            result = await FootballPlayerService.UpdateFootballPlayer(FootballPlayer);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
