int fsrAnalogPin = 0; 
int LEDpin = 11;
int fsrReading; 
int LEDbrightness;
 
void setup(void) {
  Serial.begin(9600); 
  pinMode(LEDpin, OUTPUT);
}
 
void loop(void) {
  fsrReading = analogRead(fsrAnalogPin);
  Serial.print("Analog reading = ");
  Serial.println(fsrReading);
 

  LEDbrightness = map(fsrReading, 0, 1023, 0, 255);
  analogWrite(LEDpin, LEDbrightness);
 
  delay(100);
}
