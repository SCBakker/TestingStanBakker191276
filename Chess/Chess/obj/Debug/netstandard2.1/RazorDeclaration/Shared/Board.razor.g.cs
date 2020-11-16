#pragma checksum "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\Shared\Board.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c474d64aa93d7564f4d667fb9b9479b930cb2b5"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Chess.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Chess;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\_Imports.razor"
using Chess.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\Shared\Board.razor"
using Chess.Business;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\Shared\Board.razor"
using Chess.Models;

#line default
#line hidden
#nullable disable
    public partial class Board : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "C:\Users\PC_01\Documents\ICT-VK-T-19-s2021-assignment-SCBakker.git\Chess\Chess\Shared\Board.razor"
       
    private List<Row> board;
    private string Feedback { get; set; }
    public string SelectedField { get; private set; }
    public List<string> TargetFields { get; private set; }

    public Colour PlayingNow { get; private set; }

    protected override void OnInitialized()
    {
        ChessService.StartNewGame();
        DrawBoard();
    }

    public void SetSelectedField(string selectedField)
    {
        SelectedField = selectedField;
        if (!string.IsNullOrEmpty(selectedField))
            TargetFields = ChessService.CanMoveTo(selectedField);
        else
            TargetFields = new List<string>(0);
        StateHasChanged();
    }

    public void MovePiece(string targetField)
    {
        var (succes, isChecked) = ChessService.MovePiece(SelectedField, targetField);
        if (succes)
        {
            DrawBoard();
            Feedback = isChecked ? "Check" : "";
            StateHasChanged();
        }
    }

    private void DrawBoard()
    {
        board = ChessService.GetAllFields;
        PlayingNow = ChessService.PlayingNow;
        TargetFields = new List<string>(0);
        SelectedField = "";
    }

    private string Letters => "ABCDEFGH";

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ChessService ChessService { get; set; }
    }
}
#pragma warning restore 1591
