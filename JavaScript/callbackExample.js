function callFriend(yourName, friendsName, callMeBack) {
  console.log(`ring ring, calling ${friendsName}`);
  console.log(`hey ${yourName}, let me call you back real quick`);

  setTimeout(() => {
    callMeBack(friendsName)
  }, 3000);
}

function receiveCallBack(callersName) {
  console.log(`ring ring, ${callersName} is calling you back.`);
}

callFriend("Your Name", "Friends Name", receiveCallBack)