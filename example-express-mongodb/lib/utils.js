function spyOnAllMethodsOf(obj){
  for (var m in obj) {
    if (typeof obj[m] == "function") {
        spyOn(obj, m);
    }
  }
}
