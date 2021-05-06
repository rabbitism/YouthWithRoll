import requests;
import json;

with open('data.json', 'r', encoding='utf-8') as f:
  data = json.loads(f.read())
  trainers = data["data"]["1305432785010006"]["childs"][0]["options"]

  result = list()

  for trainer in trainers:
    result.append({"Id":trainer["optionId"], "Name":trainer["text"], "picName":trainer["optionId"]+".jpg"})
    # print(trainer["picUrl"])
    #r = requests.get(trainer["picUrl"])
    #with open(trainer["optionId"]+".jpg", 'wb') as img:
      #img.write(r.content)
  
  #print(result)

  #print(json.dumps(result))

  with open("trainers.json", "w", encoding='utf-8') as trainer_f:
    trainer_f.write(json.dumps(result, ensure_ascii=False))