#include <ESP8266WiFi.h>
#include <UniversalTelegramBot.h>

#define WIFI_SSID "LamaWIFI2.4"
#define WIFI_PASSWORD "Lama1200"
#define BOT_TOKEN "" // убрал для безопасности

#define RELAY_PIN 5

WiFiClientSecure client;
UniversalTelegramBot bot(BOT_TOKEN, client);

void setup() {
  Serial.begin(9600);
  delay(10000);

  pinMode(RELAY_PIN, OUTPUT);
  digitalWrite(RELAY_PIN, LOW);

  Serial.println("Connecting to WiFi");
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  client.setInsecure();
}

void loop() {
  int numNewMessages = bot.getUpdates(bot.last_message_received + 1);

  while (numNewMessages) {
    Serial.println("debug message: have response");
    for (int i = 0; i < numNewMessages; i++) {
      String chat_id = String(bot.messages[i].chat_id);
      String text = bot.messages[i].text;

      if (text == "/on") {
        digitalWrite(RELAY_PIN, HIGH);
        bot.sendMessage(chat_id, "Relay is ON", "");
      } else if (text == "/off") {
        digitalWrite(RELAY_PIN, LOW);
        bot.sendMessage(chat_id, "Relay is OFF", "");
      }
    }
    numNewMessages = bot.getUpdates(bot.last_message_received + 1);
  }
}