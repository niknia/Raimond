import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurTeachingMethods } from '@/data/curteachingmethods/curteachingmethods.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurTeachingMethodsDto } from '@/data/curteachingmethods/curteachingmethods.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurTeachingMethods();
    const { data: curTeachingMethodsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingTeachingMethod, setEditingTeachingMethod] = useState<CurTeachingMethodsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curTeachingMethodsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurTeachingMethodsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام روش تدریس',
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
    const handleEdit = (row: CurTeachingMethodsDto) => {
        setEditingTeachingMethod(row);
        open();
    };

    const handleDelete = async (row: CurTeachingMethodsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'روش تدریس با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف روش تدریس',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingTeachingMethod(null);
        open();
    };

    const handleSave = async (values: Partial<CurTeachingMethodsDto>) => {
        try {
            if (editingTeachingMethod) {
                await updateMutation.mutateAsync({ id: editingTeachingMethod.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'روش تدریس با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'روش تدریس جدید با موفقیت ایجاد شد',
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
                    <Title order={2}>مدیریت روش‌های تدریس</Title>
                    <Text c="dimmed">مدیریت روش‌های مختلف تدریس و آموزش</Text>
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
                    title={editingTeachingMethod ? 'ویرایش روش تدریس' : 'افزودن روش تدریس جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام روش تدریس"
                            placeholder="نام روش تدریس"
                            defaultValue={editingTeachingMethod?.name || ''}
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
                                {editingTeachingMethod ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 