let menu = document.querySelector('#menu-bar');
let navbar = document.querySelector('.navbar');

menu.onclick = () =>{
    menu.classList.toggle('fa-times');
    navbar.classList.toggle('active');
}
window.onscroll = () =>{
    menu.classList.remove('fa-times');
    navbar.classList.remove('active');
}


//get modal element
var logbox = document.getElementById('modal');
//get open modal button
var modalbtn = document.getElementById('modalbtn');
//get close btn
var closebtn = document.getElementsByClassName('closebtn')[0];

//function to open modal
modalbtn.onclick = function(){
    logbox.style.display = 'block';
}
//function to close modal
closebtn.onclick = function (){
    logbox.style.display = 'none';
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == logbox) {
      logbox.style.display = "none";
    }
  }


//get modal element
var logbox = document.getElementById('modal');
//get open modal button
var modalbtn1 = document.getElementById('modalbtn1');
//get close btn
var closebtn = document.getElementsByClassName('closebtn')[0];

//function to open modal
modalbtn1.onclick = function(){
    logbox.style.display = 'block';
}
//function to close modal
closebtn.onclick = function (){
    logbox.style.display = 'none';
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == logbox) {
      logbox.style.display = "none";
    }
  }



//get modal element
var Regbox = document.getElementById('popup');
//get open modal button
var popupbtn = document.getElementById('popupbtn');
//get close btn
var endbtn = document.getElementsByClassName('endbtn')[0];

//function to open modal
popupbtn.onclick = function(){
    Regbox.style.display = 'block';
}
//function to close modal
endbtn.onclick = function (){
    Regbox.style.display = 'none';
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == Regbox) {
      Regbox.style.display = "none";
    }
}



//get modal element
var Regbox = document.getElementById('popup');
//get open modal button
var popupbtn1 = document.getElementById('popupbtn1');
//get close btn
var endbtn = document.getElementsByClassName('endbtn')[0];

//function to open modal
popupbtn1.onclick = function(){
    Regbox.style.display = 'block';
}
//function to close modal
endbtn.onclick = function (){
    Regbox.style.display = 'none';
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == Regbox) {
      Regbox.style.display = "none";
    }
}



//Get the button:
mybutton = document.getElementById("scroll-top");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0; // For Safari
  document.documentElement.scrollTop = 0; // For Chrome
}


//loader
function loader(){
    document.querySelector('.loader-container').classList.add('fade-out');
}
function fadeOut(){
    setInterval(loader, 2000);
}
window.onload = fadeOut();



//admin sidbar
let sidebar = document.querySelector(".sidebar");
let sidebarDash = document.querySelector(".sidebarDash");

sidebarDash.onclick = function(){
  sidebar.classList.toggle("active")
}
















