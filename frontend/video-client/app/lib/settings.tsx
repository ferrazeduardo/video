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
        email: 'jhon@e.com',
        age: 30,
      });
    }, 1000);
  });
};

const usuario = [{
  id: 1,
  nome: 'John Doe',
  email: 'jhon@e.com',
  idade: 30,
},
{
  id: 2,
  nome: 'Jane Doe',
  email: 'jane@e.com',
  idade: 25,
}]

export async function getUserById(id: string) {
  return usuario.filter(user => user.id == parseInt(id))[0] || null;
}
