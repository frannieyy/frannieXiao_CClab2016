#define LM35 A1
int ledg =4;
int ledr =3;

int val =0;
float temp = 0;


void setup(){
pinMode(ledg,OUTPUT);
pinMode(ledr,OUTPUT);
Serial.begin(9600);
}
void loop(){
val = analogRead(LM35);
temp = (125*val)>>8;
Serial.print("Tep=");
Serial.print(temp);
Serial.println(" C");
delay(150);

if (temp<77)
{
digitalWrite(ledg, 1);
digitalWrite(ledr, 0); 
}
else if(temp>77)
{
digitalWrite(ledr, 1); 
digitalWrite(ledg, 0); 
}
}
