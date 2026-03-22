import { getUserById } from '@/app/lib/settings';
import { notFound } from 'next/navigation';
import React from 'react';
async function User({ params }: { params: Promise<{ id: string }> }) {
    const { id } = await params;
    const user = await getUserById(id);

    if (!user) {
        notFound();
    }

    return (
        <div>
            <h1 className='text-2xl font-bold'>User</h1>

            <div className='
            border
            border-dashed
            border-red-500
            p-4'>
                <p><strong>Nome:</strong> {user.nome}</p>
                <p><strong>ID:</strong> {user.id}</p>
                <p><strong>Email:</strong> {user.email}</p>
                <p><strong>Idade:</strong> {user.idade}</p>
            </div>

        </div>
    )
}

export default User;

