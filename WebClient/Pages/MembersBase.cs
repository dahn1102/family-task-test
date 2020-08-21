using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebClient.Abstractions;

namespace WebClient.Pages
{
    public class MembersBase : ComponentBase
    {
        protected List<FamilyMember> members = new List<FamilyMember>();
        protected List<MenuItem> leftMenuItem = new List<MenuItem>();
        protected FamilyMember memberToEdit { get; set; }
        protected bool showCreator;
        protected bool isLoaded;

        [Inject]
        public IMemberDataService MemberDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await MemberDataService.GetAllMembers();

            if (result != null && result.Payload != null && result.Payload.Any())
            {
                foreach (var item in result.Payload)
                {
                    members.Add(new FamilyMember()
                    {
                        avtar = item.Avatar,
                        email = item.Email,
                        firstname = item.FirstName,
                        lastname = item.LastName,
                        role = item.Roles,
                        id = item.Id
                    });
                }
            }

            for (int i = 0; i < members.Count; i++)
            {
                var newMenuItem = new MenuItem
                {
                    iconColor = members[i].avtar,
                    label = members[i].firstname,
                    referenceId = members[i].id
                };
                newMenuItem.ClickCallback += onMemberClick;
                leftMenuItem.Add(newMenuItem);
            }
            showCreator = true;
            isLoaded = true;
        }

        protected void onAddItem()
        {
            showCreator = true;
            memberToEdit = new FamilyMember();
            StateHasChanged();
        }

        public async void onMemberClick(object sender, object member)
        {
            Console.WriteLine($"fetching data member with id: {(Guid)member.GetType().GetProperty("referenceId").GetValue(member)} to edit...");
            var id = (Guid)member.GetType().GetProperty("referenceId").GetValue(member);
            var result = await MemberDataService.GetMemberById(id);
            if (result != null && result.Payload != null)
            {
                memberToEdit = new FamilyMember()
                {
                    id = result.Payload.Id,
                    firstname = result.Payload.FirstName,
                    lastname = result.Payload.LastName,
                    email = result.Payload.Email,
                    role = result.Payload.Roles,
                    avtar = result.Payload.Avatar
                };
                StateHasChanged();
            }
        }

        protected async Task onMemberAdd(FamilyMember familyMember)
        {
            var result = await MemberDataService.Create(new Domain.Commands.CreateMemberCommand()
            {
                Avatar = familyMember.avtar,
                FirstName = familyMember.firstname,
                LastName = familyMember.lastname,
                Email = familyMember.email,
                Roles = familyMember.role
            });
            if (result != null && result.Payload != null && result.Payload.Id != Guid.Empty)
            {
                members.Add(new FamilyMember()
                {
                    avtar = result.Payload.Avatar,
                    email = result.Payload.Email,
                    firstname = result.Payload.FirstName,
                    lastname = result.Payload.LastName,
                    role = result.Payload.Roles,
                    id = result.Payload.Id
                });
                leftMenuItem.Add(new MenuItem
                {
                    iconColor = result.Payload.Avatar,
                    label = result.Payload.FirstName,
                    referenceId = result.Payload.Id
                });
                showCreator = false;
                StateHasChanged();
            }
        }

        protected async Task onMemberEdit(FamilyMember familyMember)
        {
            Console.WriteLine($"Update family member id: {familyMember.id}");
            var updateMemberCommand = new Domain.Commands.UpdateMemberCommand()
            {
                Id = familyMember.id,
                FirstName = familyMember.firstname,
                LastName = familyMember.lastname,
                Email = familyMember.email,
                Roles = familyMember.role,
                Avatar = familyMember.avtar
            };
            var result = await MemberDataService.Update(updateMemberCommand);
            if (result.Succeed)
            {
                var index = members.FindIndex(x => x.id == familyMember.id);
                members[index] = familyMember;
                index = leftMenuItem.FindIndex(x => x.referenceId == familyMember.id);
                leftMenuItem[index].iconColor = familyMember.avtar;
                leftMenuItem[index].label = familyMember.firstname;
                memberToEdit.clear();
                StateHasChanged();
            }
        }
    }
}