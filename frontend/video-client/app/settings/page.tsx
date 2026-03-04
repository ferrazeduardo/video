import React from 'react';
import { getAppSetting, getUserInfo } from '../lib/settings';

async function Settings() {
    const { name, email,age } = await getUserInfo();
    return (
        <div>
            <h1 className='text-2xl font-bold'>Pagina settings</h1>

            <div className='
            border
            border-dashed
            border-red-500
            p-4'>
                <h2 className='text-xl font-bold'>Setting</h2>
                <p>Nome: {name}</p>
                <p>Email: {email}</p>
                <p>Idade: {age}</p>
            </div>

        </div>
    )
}

export default Settings;