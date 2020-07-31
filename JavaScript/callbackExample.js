function callFriend(yourName, friendsName, callMeBack) {
  console.log(`Ring ring, calling ${friendsName}`);
  console.log(
    `${friendsName}: Hey ${yourName}, let me call you back real quick!`
  );

  setTimeout(function () {
    callMeBack(friendsName);
  }, 3000);
}

function receiveCallBack(callersName) {
  console.log(`Ring ring, ${callersName} is calling you back.`);
}

callFriend("Your Name", "Friend's Name", receiveCallBack);
