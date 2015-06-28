// The team's Facebook ids
var team = {
  arjo: {
    facebook: 786598684,
    link:     "https://keybase.io/weirdwater",
    name:     "Arjo Bruijnes",
    color:    "#ffdd03"
  },
  jori: {
    facebook: 100001225794445,
    link: "#",
    name: "Jori Regter",
    color: "#f7931e"
  },
  max: {
    facebook: 100002019214637,
    link: "http://www.maxwinsemius.com",
    name: "Max Winsemius",
    color: "#03a0e3",
  },
  menno: {
    facebook: 100007595709231,
    link: "https://youtube.com/user/mentosmenno2gmail",
    name: "Menno van den Ende",
    color: "#8bc53f"
  },
  lizzy: {
    facebook: 100002180354671,
    link: "https://www.facebook.com/lizzytheleopard",
    name: "Lizzy Lebbing",
    color: "#b3b3b3"
  }
};

updateTeam();

/**
 * Places the team member's facebook profile picture in the team member's avatar.
 */
function getFacebookPicture(name, id)
{
  $.ajax({
    datatype: "json",
    url: "http://graph.facebook.com/" + id + "/?fields=picture.width(100).height(100)"
  }).done(function (response) {
    $("#" + name + " img").attr("src", response.picture.data.url);
  });
}

/**
 * Loops through all team members
 */
function updateTeam()
{
  for (var key in team)
  {
    if (team.hasOwnProperty(key))
    {
      getFacebookPicture(key, team[key].facebook);
      $("#" + key).append($("<a>", { text: team[key].name, href: team[key].link, style: "color:"+ team[key].color}));
    }
  }
}
