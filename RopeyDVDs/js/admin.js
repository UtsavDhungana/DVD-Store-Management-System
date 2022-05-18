//admin sidbar
let sidebar = document.querySelector(".sidebar");
let sidebarDash = document.querySelector(".sidebarDash");

sidebarDash.onclick = function(){
  sidebar.classList.toggle("active")
}



document.querySelector("#modalbtn").addEventListener("click",function(){
  document.querySelector(".modaal").style.display="block";
});

document.querySelector(".popup .close-btn").addEventListener("click",function(){
  document.querySelector(".modaal").style.display="none";
});

