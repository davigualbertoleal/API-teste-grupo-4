#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>

const char* ssid = "Wokwi-GUEST";
const char* password = "";

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nConectado ao WiFi!");
}

void loop() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    
    http.begin("http://10.0.2.2:5050/api/Sensor"); 
    
    http.addHeader("Content-Type", "application/json");

    String httpRequestData = "{\"sensorNome\":\"DHT11\", \"valor\":24.5}";

    int httpResponseCode = http.POST(httpRequestData);

    Serial.print("Status: ");
    Serial.println(httpResponseCode);
    
    http.end();
  }
  delay(5000); 
}