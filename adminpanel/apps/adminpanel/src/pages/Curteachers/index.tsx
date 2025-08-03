import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput, NumberInput, Switch, Select } from '@mantine/core';
import { DateInput } from '@mantine/dates';
import { useCurTeachers } from '@/data/curteachers/curteachers.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurTeachersDto } from '@/data/curteachers/curteachers.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurTeachers();
    const { data: curTeachersData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingTeacher, setEditingTeacher] = useState<CurTeachersDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curTeachersData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurTeachersDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'firstName',
            header: 'نام',
            size: 120,
        },
        {
            accessorKey: 'lastName',
            header: 'نام خانوادگی',
            size: 150,
        },
        {
            accessorKey: 'nationalCode',
            header: 'کد ملی',
            size: 120,
        },
        {
            accessorKey: 'phoneMobile',
            header: 'شماره موبایل',
            size: 130,
        },
        {
            accessorKey: 'gender',
            header: 'جنسیت',
            size: 80,
        },
        {
            accessorKey: 'isAcademicMember',
            header: 'عضو هیئت علمی',
            size: 120,
            cell: ({ getValue }: { getValue: () => any }) => (
                <Switch 
                    checked={getValue() as boolean} 
                    disabled 
                    size="sm"
                />
            ),
        },
        {
            accessorKey: 'teacherTypeId',
            header: 'نوع معلم',
            size: 100,
        },
        {
            accessorKey: 'degreeId',
            header: 'مدرک تحصیلی',
            size: 120,
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
    const handleEdit = (row: CurTeachersDto) => {
        setEditingTeacher(row);
        open();
    };

    const handleDelete = async (row: CurTeachersDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'معلم با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف معلم',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingTeacher(null);
        open();
    };

    const handleSave = async (values: Partial<CurTeachersDto>) => {
        try {
            if (editingTeacher) {
                await updateMutation.mutateAsync({ id: editingTeacher.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'معلم با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'معلم جدید با موفقیت ایجاد شد',
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
                    <Title order={2}>مدیریت معلمان</Title>
                    <Text c="dimmed">مدیریت اطلاعات معلمان و اساتید</Text>
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
                    title={editingTeacher ? 'ویرایش معلم' : 'افزودن معلم جدید'}
                    size="lg"
                >
                    <Stack gap="md">
                        <Group grow>
                            <TextInput
                                label="نام"
                                placeholder="نام معلم"
                                defaultValue={editingTeacher?.firstName || ''}
                                name="firstName"
                            />
                            <TextInput
                                label="نام خانوادگی"
                                placeholder="نام خانوادگی معلم"
                                defaultValue={editingTeacher?.lastName || ''}
                                name="lastName"
                            />
                        </Group>
                        
                        <Group grow>
                            <TextInput
                                label="کد ملی"
                                placeholder="کد ملی"
                                defaultValue={editingTeacher?.nationalCode || ''}
                                name="nationalCode"
                            />
                            <TextInput
                                label="شماره موبایل"
                                placeholder="شماره موبایل"
                                defaultValue={editingTeacher?.phoneMobile || ''}
                                name="phoneMobile"
                            />
                        </Group>

                        <Group grow>
                            <TextInput
                                label="تلفن ثابت"
                                placeholder="تلفن ثابت"
                                defaultValue={editingTeacher?.phoneLandline || ''}
                                name="phoneLandline"
                            />
                            <TextInput
                                label="کد پستی"
                                placeholder="کد پستی"
                                defaultValue={editingTeacher?.postalCode || ''}
                                name="postalCode"
                            />
                        </Group>

                        <TextInput
                            label="آدرس"
                            placeholder="آدرس کامل"
                            defaultValue={editingTeacher?.address || ''}
                            name="address"
                        />

                        <Group grow>
                            <TextInput
                                label="نام پدر"
                                placeholder="نام پدر"
                                defaultValue={editingTeacher?.fatherName || ''}
                                name="fatherName"
                            />
                            <TextInput
                                label="محل تولد"
                                placeholder="محل تولد"
                                defaultValue={editingTeacher?.birthPlace || ''}
                                name="birthPlace"
                            />
                        </Group>

                        <Group grow>
                            <DateInput
                                label="تاریخ تولد"
                                placeholder="تاریخ تولد"
                                defaultValue={editingTeacher?.birthDate ? new Date(editingTeacher.birthDate) : undefined}
                                name="birthDate"
                                valueFormat="YYYY/MM/DD"
                            />
                            <Select
                                label="جنسیت"
                                placeholder="انتخاب جنسیت"
                                data={[
                                    { value: 'male', label: 'مرد' },
                                    { value: 'female', label: 'زن' }
                                ]}
                                defaultValue={editingTeacher?.gender || ''}
                                name="gender"
                            />
                        </Group>

                        <Group grow>
                            <TextInput
                                label="شماره شناسنامه"
                                placeholder="شماره شناسنامه"
                                defaultValue={editingTeacher?.idNumber || ''}
                                name="idNumber"
                            />
                            <TextInput
                                label="محل صدور شناسنامه"
                                placeholder="محل صدور شناسنامه"
                                defaultValue={editingTeacher?.idIssuePlace || ''}
                                name="idIssuePlace"
                            />
                        </Group>

                        <TextInput
                            label="وضعیت نظام وظیفه"
                            placeholder="وضعیت نظام وظیفه"
                            defaultValue={editingTeacher?.militaryStatus || ''}
                            name="militaryStatus"
                        />

                        <Group grow>
                            <NumberInput
                                label="نوع معلم"
                                placeholder="نوع معلم"
                                defaultValue={editingTeacher?.teacherTypeId ?? undefined}
                                name="teacherTypeId"
                            />
                            <NumberInput
                                label="مدرک تحصیلی"
                                placeholder="مدرک تحصیلی"
                                defaultValue={editingTeacher?.degreeId ?? undefined}
                                name="degreeId"
                            />
                        </Group>

                        <Group grow>
                            <NumberInput
                                label="رشته تحصیلی"
                                placeholder="رشته تحصیلی"
                                defaultValue={editingTeacher?.fieldOfStudyId ?? undefined}
                                name="fieldOfStudyId"
                            />
                            <NumberInput
                                label="وضعیت تاهل"
                                placeholder="وضعیت تاهل"
                                defaultValue={editingTeacher?.maritalStatusId ?? undefined}
                                name="maritalStatusId"
                            />
                        </Group>

                        <Group grow>
                            <NumberInput
                                label="دین"
                                placeholder="دین"
                                defaultValue={editingTeacher?.religionId ?? undefined}
                                name="religionId"
                            />
                            <NumberInput
                                label="مذهب"
                                placeholder="مذهب"
                                defaultValue={editingTeacher?.denominationId ?? undefined}
                                name="denominationId"
                            />
                        </Group>

                        <Switch
                            label="عضو هیئت علمی"
                            defaultChecked={editingTeacher?.isAcademicMember || false}
                            name="isAcademicMember"
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        firstName: (formData.get('firstName') as string) || '',
                                        lastName: (formData.get('lastName') as string) || '',
                                        nationalCode: (formData.get('nationalCode') as string) || '',
                                        phoneMobile: (formData.get('phoneMobile') as string) || '',
                                        phoneLandline: (formData.get('phoneLandline') as string) || '',
                                        postalCode: (formData.get('postalCode') as string) || '',
                                        address: (formData.get('address') as string) || '',
                                        fatherName: (formData.get('fatherName') as string) || '',
                                        birthPlace: (formData.get('birthPlace') as string) || '',
                                        birthDate: formData.get('birthDate') as string || '',
                                        gender: (formData.get('gender') as string) || '',
                                        idNumber: (formData.get('idNumber') as string) || '',
                                        idIssuePlace: (formData.get('idIssuePlace') as string) || '',
                                        militaryStatus: (formData.get('militaryStatus') as string) || '',
                                        teacherTypeId: formData.get('teacherTypeId') ? Number(formData.get('teacherTypeId')) : undefined,
                                        degreeId: formData.get('degreeId') ? Number(formData.get('degreeId')) : undefined,
                                        fieldOfStudyId: formData.get('fieldOfStudyId') ? Number(formData.get('fieldOfStudyId')) : undefined,
                                        maritalStatusId: formData.get('maritalStatusId') ? Number(formData.get('maritalStatusId')) : undefined,
                                        religionId: formData.get('religionId') ? Number(formData.get('religionId')) : undefined,
                                        denominationId: formData.get('denominationId') ? Number(formData.get('denominationId')) : undefined,
                                        isAcademicMember: formData.get('isAcademicMember') === 'on',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingTeacher ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
}
