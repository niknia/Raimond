export const generateChartData = (days: number) => {
  const data = [];
  for (let i = 0; i < days; i++) {
    data.push({
      name: `Day ${i + 1}`,
      value: Math.floor(Math.random() * 1000) + 500
    });
  }
  return data;
};

export const generateTimeSeriesData = (hours: number, min: number, max: number) => {
  const data = [];
  for (let i = 0; i < hours; i++) {
    const time = new Date();
    time.setHours(time.getHours() - (hours - i - 1));
    data.push({
      time: time.toISOString().substr(11, 5),
      value: Math.floor(Math.random() * (max - min)) + min
    });
  }
  return data;
}; 