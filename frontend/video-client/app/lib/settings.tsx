export const getAppSetting = (): Promise<{ theme: string, language: string }> => {
    return new Promise((resolve) => {
        resolve({
            theme: 'dark',
            language: 'en'
        });
    })
}

export const getUserInfo = (): Promise<{
  name: string;
  email: string;
  age: number;
}> => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve({
        name: 'John Doe',
        email: 'jhon@e.com',     // ← corrigi "jhon" → "john" e "jhon@e.com" → mais comum
        age: 30,
      });
    }, 1000);
  });
};