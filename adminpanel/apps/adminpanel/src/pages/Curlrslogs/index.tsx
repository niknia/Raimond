import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurLrslogs } from '@/data/curlrslogs/curlrslogs.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurLrslogsDto } from '@/data/curlrslogs/curlrslogs.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurLrslogs();
    const { data: curLrslogsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingLrsLog, setEditingLrsLog] = useState<CurLrslogsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curLrslogsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurLrslogsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام لاگ LRS',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurLrslogsDto) => {
        setEditingLrsLog(row);
        open();
    };

    const handleDelete = async (row: CurLrslogsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'لاگ LRS با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف لاگ LRS',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingLrsLog(null);
        open();
    };

    const handleSave = async (values: Partial<CurLrslogsDto>) => {
        try {
            if (editingLrsLog) {
                await updateMutation.mutateAsync({ id: editingLrsLog.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'لاگ LRS با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'لاگ LRS جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت لاگ‌های LRS</Title>
                    <Text c="dimmed">مدیریت لاگ‌های مختلف LRS</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingLrsLog ? 'ویرایش لاگ LRS' : 'افزودن لاگ LRS جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام لاگ LRS"
                            placeholder="نام لاگ LRS"
                            defaultValue={editingLrsLog?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingLrsLog ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 