#
BEGIN{
units="zero one two three four five six seven eight nine"
double=\
"ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen"
tens="twenty thirty fourty fifty"
split(units, spku); split(double, spkd); split(tens, spkt)
# obtain the time
{split($4, time, ":")
# obtain hour of the day (zero .. twenty-three)
if(time[1]<20){
if(time[1]<10)hour=spku[time[1]+1]
else hour=spkd[time[1]-10]+11}
else{
if((time[1]%10)<1)hour=spkt[int(time[1]/10)-1]
else hour=spkt[int(time[1]/10)-1]1 " " spku[(time[1]%10)+1]}
# obtain minutes of the hour (zero fifty-nine)
if(time[2]<20){
if(time[2]<10)minute=spku[time[2]+1]
else minute=spkd[(time[2]-10)+1]}
else{
if((time[2]%10)<1)minute=spkt[int(time[2]/10)-1]
else minute=spkt[int(time[2]/10)-1] " " spku[(time[2]%10)+1]}
# obtain seconds of the minute (zero fifty-nine)
if(time[3]<20){
if(time[3]<10)second=spku[time[3]+1]
else second=spkd[(time[3]-10)+1]}
else{
if((time[3]%10)<1)second=spkt[int(time[3]/10)-1]
else second=spkt[int(time[3]/10)-1] " " spku[(time[3]%10)+1]}
}
}
END{
printf"La Hora es \n"
printf"%s horas %s minutos y %s segundos exactamente \n",hour,minute,second
}
