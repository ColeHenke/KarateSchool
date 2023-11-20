<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateSchool.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            height: 246px;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hi,
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="memberGridView" runat="server" OnSelectedIndexChanged="memberGridView_SelectedIndexChanged">
                        </asp:GridView><selection-overlay style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><blocked-overlay><br class="Apple-interchange-newline"><div class="blockedOverlayWrapper" style="position: absolute; top: 0px; left: 0px; width: 764px; height: 486px; pointer-events: none;"><blocked-overlay-rect height="4.76837158203125e-7" width="764" top="485.99999952316284" left="0"><div class="blockedOverlayRect" style="position: absolute; cursor: not-allowed; background-color: rgba(0, 0, 0, 0.3); pointer-events: auto; top: 486px; left: 0px; width: 764px; height: 4.76837e-07px;"></div></blocked-overlay-rect></div></blocked-overlay><selector-parent-decorator></selector-parent-decorator><selector-insertion-decorator></selector-insertion-decorator><selector-decorator draggable="true" taglocation="Top" hasactionitems=""><div id="elementOutline" style="position: fixed; border-style: solid; border-width: 1px; border-color: var(--wlp-selection-color); outline-style: none; height: 126.667px; width: 200.042px; top: 79.3333px; left: 9px;"><div class="selectionTag" tabindex="0" role="alert" aria-label="Selected Element " style="background-color: var(--wlp-selection-color); display: flex; position: absolute; font-weight: bold; white-space: nowrap; align-items: center; padding: 3px 10px; border-radius: 3px; box-sizing: border-box; box-shadow: var(--wlp-box-shadow); color: var(--wlp-tag-text-color); font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); cursor: pointer; pointer-events: all; top: calc(-1 * var(--wlp-status-bar-height)); left: 0px;">asp:gridview#memberGridView<span aria-label="Action Panel Indicator" role="button" class="actionPanelIndicator" style="display: inline; margin-left: 5px;">»</span></div></div></selector-decorator><secondary-selections style="pointer-events: none;"></secondary-selections><drag-and-drop-insertion-point mousex="-1" mousey="-1"></drag-and-drop-insertion-point></selection-overlay><span style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"></span><blocked-resources-toast class="blocked-resources-toast" rooturl="http://localhost:61389/87b57bd82ec9457cad10aeb6ef002af6/" style="font-family: &quot;Times New Roman&quot;; font-size: medium; line-height: var(--type-ramp-base-line-height); z-index: var(--wlp-alert-zIndex); color: rgb(0, 0, 0); position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></blocked-resources-toast><span style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"></span><wlp-status-bar style="display: grid; grid-template-columns: minmax(0px, 1fr) max-content; position: fixed; box-shadow: var(--wlp-box-shadow); height: var(--wlp-status-bar-height); width: 764px; bottom: 0px; left: 0px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: ; font-variant-east-asian: ; font-variant-alternates: ; font-variant-position: ; font-weight: 400; font-stretch: ; font-size: medium; line-height: ; font-family: &quot;Times New Roman&quot;; font-optical-sizing: ; font-kerning: ; font-feature-settings: ; font-variation-settings: ; background-color: var(--neutral-layer-4); color: rgb(0, 0, 0); letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><wlp-tag-navigator overflow-direction="none" style="max-height: var(--wlp-status-bar-height); display: grid; grid-template-columns: max-content minmax(0px, max-content) max-content;"><fluent-button id="leftScroller" appearance="stealth" aria-label="Left Scroller" class="tagNavBar_scroller stealth disabled" disabled="" current-value="" style="display: inline-block; position: relative; box-sizing: border-box; font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); line-height: var(--type-ramp-base-line-height); font-weight: bold; font-variation-settings: var(--type-ramp-base-font-variations); height: calc((var(--base-height-multiplier) + var(--density)) * var(--design-unit) * 1px); min-width: calc((var(--base-height-multiplier) + var(--density)) * var(--design-unit) * 1px); color: var(--neutral-foreground-hint); border-radius: calc(var(--control-corner-radius) * 1px); fill: currentcolor; user-select: none;"><button class="control" part="control" disabled="" value="" aria-label="Left Scroller" style="border: calc(var(--stroke-width) * 1px) solid transparent; flex-grow: 1; box-sizing: border-box; display: inline-flex; justify-content: center; align-items: center; padding: 0 calc((10 + (var(--design-unit) * 2 * var(--density))) * 1px); white-space: nowrap; outline: none; text-decoration: none; color: inherit; border-radius: inherit; fill: inherit; font: inherit; background: var(--neutral-fill-stealth-rest); cursor: not-allowed; opacity: var(--disabled-opacity); height: inherit;"><span part="start"><slot name="start"></slot></span><span class="content" part="content" style="pointer-events: none;"><slot>&lt;</slot></span><span part="end"><slot name="end"></slot></span></button></fluent-button><div class="tagNavBar_container" style="max-height: var(--wlp-status-bar-height); white-space: nowrap; overflow-x: hidden; --density: -1;"><ul class="tagNavBar_contents" style="display: inline-block; list-style: none; margin-block: 0px; padding-inline: 0px;"><li class="tagNavBar_tagItem" style="cursor: pointer; user-select: none; display: inline-block; font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); margin-right: 4px;"><fluent-button appearance="stealth" class="stealth" aria-label="Root" data-selected="false" current-value="" style="display: inline-flex; position: relative; box-sizing: border-box; font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); line-height: var(--type-ramp-base-line-height); font-weight: initial; font-variation-settings: var(--type-ramp-base-font-variations); height: calc((var(--base-height-multiplier) + var(--density)) * var(--design-unit) * 1px); min-width: calc((var(--base-height-multiplier) + var(--density)) * var(--design-unit) * 1px); color: var(--neutral-foreground-rest); border-radius: calc(var(--control-corner-radius) * 1px); fill: currentcolor;"><button class="control" part="control" value="" aria-label="Root" style="border: calc(var(--stroke-width) * 1px) solid transparent; flex-grow: 1; box-sizing: border-box; display: inline-flex; justify-content: center; align-items: center; padding: 0 calc((10 + (var(--design-unit) * 2 * var(--density))) * 1px); white-space: nowrap; outline: none; text-decoration: none; color: inherit; border-radius: inherit; fill: inherit; font: inherit; background: var(--neutral-fill-stealth-rest); cursor: pointer; height: inherit;"><span part="start"><slot name="start"></slot></span><span class="content" part="content" style="pointer-events: none;"><slot>Root</slot></span><span part="end"><slot name="end"></slot></span></button></fluent-button></li><span> </span></ul></div></wlp-tag-navigator></wlp-status-bar>
                        <br />
                        <asp:Label runat="server" Text="Member ID:" ID="memberIdLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="memberIdTextBox"></asp:TextBox><br />
                        
                        <asp:Label runat="server" Text="First Name:" ID="memberFistNameLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="memberFirstNameTextBox"></asp:TextBox><br />
                        
                        <asp:Label runat="server" Text="Last Name:" ID="memberLastNameLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="memberLastNameTextBox"></asp:TextBox><br />
                        
                        <asp:Label runat="server" Text="Phone Number:" ID="memberPhoneNumberLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="memberPhoneNumberTextBox"></asp:TextBox><br />

                        <asp:Label runat="server" Text="Email:" ID="memberEmailLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="memberEmailTextBox"></asp:TextBox><br />
                         <asp:Button ID="addMemberButton" runat="server" Text="Add " OnClick="addMemberButton_Click" />
                        <asp:Button ID="deleteMemberButton" runat="server" Text="Delete" OnClick="deleteMemberButton_Click" /></td>
                    <td class="auto-style2">
                        <asp:GridView ID="instructorGridView" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Label runat="server" Text="Instructor ID:" ID="instructorIdLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="instructorIdTextBox"></asp:TextBox><br />

                        <asp:Label runat="server" Text="First Name:" ID="instructorFirstNameLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="instructorFirstNameTextBox"></asp:TextBox><br />

                        <asp:Label runat="server" Text="Last Name" ID="instructorLastNameLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="instructorLastNameTextBox"></asp:TextBox><br />

                        <asp:Label runat="server" Text="Phone Number" ID="instructorPhoneNumberLabel"></asp:Label>
                        <asp:TextBox runat="server" ID="instructorPhoneNumberTextBox"></asp:TextBox><br />
                        <asp:Button ID="addInstructorButton" runat="server" Text="Add" OnClick="addInstructorButton_Click" />
                        <asp:Button ID="deleteInstructorButton" runat="server" Text="Delete" OnClick="deleteInstructorButton_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="auto-style2">
                <asp:GridView ID="sectionGridView" runat="server">
                </asp:GridView>
                <div class="auto-style2">
                    <br />
                    <asp:Label runat="server" Text="Scetion ID:" ID="sectionIdLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="sectionIdTextBox"></asp:TextBox><br />

                    <asp:Label runat="server" Text="Section Name:" ID="sectionNameLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="sectionNameTextBox"></asp:TextBox><br />

                    <asp:Label runat="server" Text="Start Date:" ID="sectionStartDateLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="sectionStartDateTextBox"></asp:TextBox><br />

                    <asp:Label runat="server" Text="Member ID:" ID="memberInSectionLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="memberInSectionTextBox"></asp:TextBox><br />  

                    <asp:Label runat="server" Text="Instructor ID:" ID="instructorInSectionLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="instructorInSectionTextBox"></asp:TextBox><br />

                    <asp:Label runat="server" Text="Section Fee:" ID="sectionFeeLabel"></asp:Label>
                    <asp:TextBox runat="server" ID="sectionFeeTextBox"></asp:TextBox><br />

                    <asp:Button ID="addSectionButton" runat="server" Text="Add" OnClick="addSectionButton_Click" />
                    <asp:Button ID="deleteSectionButton" runat="server" Text="Delete" OnClick="deleteSectionButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
